import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { Gender } from 'src/app/models/Customer';
import { ApiCustomerService } from 'src/app/services/api.customer.service';
import { ApiOfferService } from 'src/app/services/api.offer.service';
import { RegistrationService } from 'src/app/services/registration.service';

@Component({
  selector: 'app-insuredinformation',
  templateUrl: './insured.component.html',
  styleUrls: ['./insured.component.scss'],
})
export class InsuredComponent implements OnInit {
  public genders: any[];
  public formGroup: FormGroup;
  public isLoading: boolean;

  constructor(
    private registrationService: RegistrationService,
    private apiOffer: ApiOfferService,
    private apiCustomer: ApiCustomerService,
    private router: Router,
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
    this.isLoading = false;
    this.formGroup = this.fb.group({
      tcNo: [null, this.match.bind(this)],
      passaport: [null, this.match.bind(this)],
      name: [null, Validators.required],
      surname: [null, Validators.required],
      gender: [null, Validators.required],
      gsm: [null, [Validators.required, Validators.minLength(10)]],
      mail: [null, [Validators.required, Validators.email]],
      address: [null, Validators.required],
      birthdate: [null, Validators.required],
    });
  }

  ngOnInit(): void {
    this.registrationService.resetData();
  }

  submitForm() {
    if (this.formGroup.valid) {
      this.isLoading = true;
      this.formGroup.disable();
      this.apiCustomer.addCustomer(this.formGroup.value).subscribe((x) => {
        this.apiOffer
          .AddOffer({ customerId: x.data.customerId })
          .subscribe((y) => {
            this.registrationService.data.customer = x.data;
            this.registrationService.data.offerNumber = y.data.offerNumber;
            this.registrationService.data.offerStatus = y.data.offerStatus;
            this.router.navigate([
              'registration',
              y.data.offerNumber,
              `insurer`,
            ]);
          });
      });
    }
  }

  match(): ValidationErrors | null {
    const tc = this.formGroup?.get('tcNo');
    const passaport = this.formGroup?.get('passaport');

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
}
