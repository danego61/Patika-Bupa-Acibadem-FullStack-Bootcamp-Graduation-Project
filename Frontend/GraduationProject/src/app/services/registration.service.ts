import { Injectable } from '@angular/core';
import { Offer, OfferStatus } from '../models/offer';

@Injectable({
  providedIn: 'root',
})
export class RegistrationService {
  data: Offer;

  constructor() {
    this.data = this.getOfferInitValue();
  }

  getData() {
    return this.data;
  }

  resetData() {
    this.data = this.getOfferInitValue();
  }

  getOfferInitValue(): Offer {
    return {
      offerNumber: -1,
      billId: undefined,
      offerStatus: OfferStatus.insurerAdding,
      endTime: undefined,
      bill: undefined,
      customer: undefined,
      selectedProduct: undefined,
      offerDetails: [],
    };
  }
}
