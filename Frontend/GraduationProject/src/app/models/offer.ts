import { Bill } from './Bill';
import { Customer } from './Customer';
import { Product } from './product';

export interface Offer {
  offerNumber: number;

  billId: number | undefined;

  offerStatus: OfferStatus;

  endTime: Date | undefined;

  bill: Bill | undefined;

  customer: Customer | undefined;

  selectedProduct: Product | undefined;

  offerDetails: Array<OfferDetail>;
}

export interface OfferDetail {
  offerId: number;

  customerId: string;

  height: number;

  weight: number;

  relationship: Relationships;

  job: string;

  customer: Customer;
}

export enum OfferStatus {
  insuredsAdding,

  productSelection,

  installmentSelection,

  paymentPending,

  completed,

  insurerAdding,
}

export enum Relationships {
  itSelf,

  partner,

  child,
}

export class AddOfferModel {
  constructor(public customerId: string) {}
}

export class AddOfferDetailModel {
  constructor(
    public customerId: string,
    public height: number,
    public weight: number,
    public relationship: Relationships,
    public job: string
  ) {}
}

export class OfferUpdateProduct {
  constructor(
    public offerNumber: number,
    public selectedProduct: number,
    public offerStatus: OfferStatus
  ) {}
}
