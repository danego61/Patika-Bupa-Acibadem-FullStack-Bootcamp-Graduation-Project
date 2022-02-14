import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { OfferStatus } from 'src/app/models/offer';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss'],
})
export class RegistrationComponent implements OnInit, OnDestroy {
  items: MenuItem[] | any;
  currentIndex: number;
  observer: any;

  constructor(private router: Router) {
    this.currentIndex = 0;
  }
  ngOnDestroy(): void {
    this.observer.unsubscribe();
  }

  ngOnInit(): void {
    this.observer = this.router.events.subscribe((x) => {
      if (x instanceof NavigationEnd) {
        this.updateIndex(x.url);
      }
    });
    this.updateIndex(this.router.url);
    this.items = [
      {
        label: 'Sigorta Ettiren Girişi',
      },
      {
        label: 'Sigortalı Girişi',
      },
      {
        label: 'Ürün Seçimi',
      },
      {
        label: 'Prim Bilgileri',
      },
      {
        label: 'Ödeme',
      },
    ];
  }

  updateIndex(url: string) {
    this.currentIndex = url.endsWith('insurer')
      ? 1
      : url.endsWith('product')
      ? 2
      : url.endsWith('premium')
      ? 3
      : url.endsWith('payment')
      ? 4
      : 0;
  }

  static RedirectRoute(
    router: Router,
    status: OfferStatus,
    offerNumber: number
  ) {
    switch (status) {
      case OfferStatus.insurerAdding:
      case OfferStatus.completed:
        router.navigate(['registration/insured']);
        break;
      case OfferStatus.insuredsAdding:
        router.navigate(['registration', offerNumber, 'insurer']);
        break;
      case OfferStatus.productSelection:
        router.navigate(['registration', offerNumber, 'product']);
        break;
      case OfferStatus.installmentSelection:
        router.navigate(['registration', offerNumber, 'premium']);
        break;
      case OfferStatus.paymentPending:
        router.navigate(['registration', offerNumber, 'payment']);
        break;
    }
  }
}
