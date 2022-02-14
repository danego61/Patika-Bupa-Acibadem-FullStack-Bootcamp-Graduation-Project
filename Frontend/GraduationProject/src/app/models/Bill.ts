export interface Bill {

  billId : Number;

  amount : Number;

  installment : InstallmentTypes;

  payment : BillPayment;

}

export enum InstallmentTypes {

  advance,

  installment3,

  installment6,

  installment9,

}

export interface BillPayment {

  paymentId : Number;

  cardNo : string;

  cardName : string;

  cardDateMounth : Number;

  cardDateYear : Number;

  cardType : string;

}
