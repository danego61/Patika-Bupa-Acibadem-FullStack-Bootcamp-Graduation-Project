import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { InstallmentTypes } from 'src/app/models/Bill';
import { OfferStatus } from 'src/app/models/offer';
import { ApiOfferService } from 'src/app/services/api.offer.service';
import { RegistrationService } from 'src/app/services/registration.service';
import { RegistrationComponent } from '../../registration.component';

@Component({
  selector: 'app-premium',
  templateUrl: './premium.component.html',
  styleUrls: ['./premium.component.scss'],
})
export class PremiumComponent implements OnInit {
  private offerId!: number;
  public isLoading: boolean = false;
  public installments: any[];
  public formGroup: FormGroup;
  constructor(
    private registrationService: RegistrationService,
    private apiOffer: ApiOfferService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.formGroup = this.fb.group({
      installment: [null, Validators.required],
    });
    this.installments = [
      {
        name: "Peşin",
        value: InstallmentTypes.advance.valueOf()
      },
      {
        name: "3 taksit",
        value: InstallmentTypes.installment3.valueOf()
      },
      {
        name: "6 taksit",
        value: InstallmentTypes.installment6.valueOf()
      },
      {
        name: "9 taksit",
        value: InstallmentTypes.installment9.valueOf()
      }
    ]
  }

  ngOnInit(): void {
    this.offerId = parseInt(this.route.snapshot.paramMap.get('id')!);
    if (
      this.registrationService.data.offerStatus != OfferStatus.productSelection
    ) {
      this.changeLoading(true);
      this.apiOffer.GetOffer(this.offerId).subscribe(
        (x) => {
          this.changeLoading(false);
          this.registrationService.data = x.data;
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
  }

  nextStep() {
    if(this.formGroup.valid) {
      this.changeLoading(true);
      this.apiOffer.UpdateOfferInstallment(this.offerId, this.formGroup.value).subscribe(x => {
        this.registrationService.data.offerStatus = OfferStatus.paymentPending;
        this.changeLoading(false);
        this.router.navigate(['registration', this.offerId, 'payment']);
      });
    }
  }

  changeLoading(loading: boolean) {
    this.isLoading = loading;
    if (loading) this.formGroup.disable();
    else this.formGroup.enable();
  }
}
