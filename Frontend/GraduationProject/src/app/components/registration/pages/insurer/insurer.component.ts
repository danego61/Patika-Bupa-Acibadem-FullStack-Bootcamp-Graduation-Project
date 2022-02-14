import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OfferDetail, OfferStatus, Relationships } from 'src/app/models/offer';
import { ApiOfferService } from 'src/app/services/api.offer.service';
import { RegistrationService } from 'src/app/services/registration.service';
import { RegistrationComponent } from '../../registration.component';
import { Customer, Gender } from 'src/app/models/Customer';
import {
  FormBuilder,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { ApiCustomerService } from 'src/app/services/api.customer.service';

@Component({
  selector: 'app-insurerinformation',
  templateUrl: './insurer.component.html',
  styleUrls: ['./insurer.component.scss'],
})
export class InsurerComponent implements OnInit {
  private offerId!: number;
  public isLoading: boolean = false;
  public genders: any[];
  public formGroup!: FormGroup;
  public relationships: any[];
  public insurers: any[] = [];

  constructor(
    private registrationService: RegistrationService,
    private apiOffer: ApiOfferService,
    private apiCustomer: ApiCustomerService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.genders = [
      {
        name: 'Kadın',
        value: Gender.female.valueOf(),
      },
      {
        name: 'Erkek',
        value: Gender.male.valueOf(),
      },
    ];
    this.relationships = [
      {
        name: 'Kendisi',
        value: Relationships.itSelf.valueOf(),
      },
      {
        name: 'Eşi',
        value: Relationships.partner.valueOf(),
      },
      {
        name: 'Çocuğu',
        value: Relationships.child.valueOf(),
      },
    ];
    this.formGroup = this.fb.group({
      customer: this.fb.group({
        tcNo: [null, this.match.bind(this)],
        passaport: [null, this.match.bind(this)],
        name: [null, Validators.required],
        surname: [null, Validators.required],
        gender: [null, Validators.required],
        gsm: [null, [Validators.required, Validators.minLength(10)]],
        mail: [null, [Validators.required, Validators.email]],
        address: [null, Validators.required],
        birthdate: [null, Validators.required],
      }),
      offerDetail: this.fb.group({
        height: [null, Validators.required],
        weight: [null, Validators.required],
        job: [null, Validators.required],
        relationship: [null, Validators.required],
      }),
    });
  }

  ngOnInit(): void {
    this.offerId = parseInt(this.route.snapshot.paramMap.get('id')!);
    if (
      this.registrationService.data.offerStatus != OfferStatus.insuredsAdding
    ) {
      this.changeLoading(true);
      this.apiOffer.GetOffer(this.offerId).subscribe(
        (x) => {
          this.changeLoading(false);
          this.registrationService.data = x.data;
          for (let detail of x.data.offerDetails) {
            this.insurers.push({
              customer: detail.customer,
              detail: detail,
            });
          }
          RegistrationComponent.RedirectRoute(
            this.router,
            this.registrationService.data.offerStatus,
            this.offerId
          );
        },
        (e) => {
          RegistrationComponent.RedirectRoute(
            this.router,
            OfferStatus.insurerAdding,
            0
          );
        }
      );
    }
    for (let detail of this.registrationService.data.offerDetails) {
      this.insurers.push({
        customer: detail.customer,
        detail: detail,
      });
    }
  }

  addCustomer() {
    if (this.formGroup.valid) {
      this.changeLoading(true);
      const customerGroup = this.formGroup.get('customer') as FormGroup;
      this.apiCustomer.addCustomer(customerGroup.value).subscribe((x) => {
        const offerDetailGroup = this.formGroup.get('offerDetail') as FormGroup;
        const data = {
          customerId: x.data.customerId,
          ...offerDetailGroup.value,
        };
        this.apiOffer.AddOfferDetail(this.offerId, data).subscribe((y) => {
          this.changeLoading(false);
          this.insurers.push({
            customer: x.data,
            detail: data,
          });
          this.formGroup.reset();
          this.registrationService.data.offerDetails.push({
            customer: x.data,
            ...data,
          });
        });
      });
    }
  }

  completeAdding() {
    if (this.insurers.length > 0) {
      this.apiOffer.CompleteAdding(this.offerId).subscribe((x) => {
        this.registrationService.data.offerStatus =
          OfferStatus.productSelection;
        this.router.navigate(['registration', this.offerId, 'product']);
      });
    }
  }

  changeLoading(loading: boolean) {
    this.isLoading = loading;
    if (loading) this.formGroup.disable();
    else this.formGroup.enable();
  }

  match(): ValidationErrors | null {
    const customerGroup = this.formGroup?.get('customer') as FormGroup;
    const tc = customerGroup?.get('tcNo');
    const passaport = customerGroup?.get('passaport');

    if (
      (!tc || !tc.value || tc.value.trim() == '') &&
      (!passaport || !passaport.value || passaport.value.trim() === '')
    ) {
      return { tcNo: 'hata', passaport: 'hata' };
    }
    tc?.setErrors(null);
    passaport?.setErrors(null);
    return null;
  }

  formatDate(dat: Date) {
    const date = new Date(dat);
    let month = '' + (date.getMonth() + 1),
      day = '' + date.getDate(),
      year = date.getFullYear();

    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;

    return [year, month, day].join('-');
  }
}
