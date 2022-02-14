import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { OfferStatus } from 'src/app/models/offer';
import { Product } from 'src/app/models/product';
import { ApiOfferService } from 'src/app/services/api.offer.service';
import { ApiProductService } from 'src/app/services/api.product.service';
import { RegistrationService } from 'src/app/services/registration.service';
import { RegistrationComponent } from '../../registration.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit {
  private offerId!: number;
  public isLoading: boolean = false;
  public products: Product[] = [];
  public formGroup: FormGroup;
  constructor(
    private registrationService: RegistrationService,
    private apiOffer: ApiOfferService,
    private apiProduct: ApiProductService,
    private router: Router,
    private route: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.formGroup = this.fb.group({
      productId: [null, Validators.required],
    });
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
          this.initProducts();
        },
        (e) => {
          RegistrationComponent.RedirectRoute(
            this.router,
            OfferStatus.insurerAdding,
            0
          );
        }
      );
    } else {
      this.initProducts();
    }
  }

  initProducts() {
    this.apiProduct.GetProducts().subscribe((x) => {
      this.products.push(...x.data);
    });
  }

  nextStep() {
    if (this.formGroup.valid) {
      this.changeLoading(true);
      this.apiOffer
        .UpdateOfferProduct(this.offerId, this.formGroup.value)
        .subscribe((x) => {
          this.registrationService.data.offerStatus = OfferStatus.completed;
          this.changeLoading(false);
          this.router.navigate(['registration', this.offerId, 'premium']);
        });
    }
  }

  changeLoading(loading: boolean) {
    this.isLoading = loading;
    if (loading) this.formGroup.disable();
    else this.formGroup.enable();
  }
}
