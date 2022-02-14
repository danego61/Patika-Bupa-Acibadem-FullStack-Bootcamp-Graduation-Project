export interface Customer {

  customerId : string;

  tcNo : string | undefined;

  passaport : string | undefined;

  name : string;

  surname : string;

  gender : Gender;

  gsm : string;

  mail : string;

  address : string;

  birthdate : Date;

}

export enum Gender {

  female,

  male

}
