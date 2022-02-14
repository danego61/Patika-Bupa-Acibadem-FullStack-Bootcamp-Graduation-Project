import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Gender } from 'src/app/models/Customer';
import { OfferStatus, Relationships } from 'src/app/models/offer';
import { PolicyStatus } from 'src/app/models/policy';
import { ApiOfferService } from 'src/app/services/api.offer.service';

@Component({
  selector: 'app-management',
  templateUrl: './management.component.html',
  styleUrls: ['./management.component.scss'],
})
export class ManagementComponent implements OnInit {
  public formGroup: FormGroup;
  public offerStatus: any[];
  public policyStatus: any[];
  public isLoading: boolean = false;
  public results: any[] = [];
  public genders: any[];
  public relationships: any[];

  constructor(private fb: FormBuilder, private apiOffer: ApiOfferService) {
    this.formGroup = fb.group({
      byInsurerTC: null,
      byInsurerName: null,
      byInsurerSurname: null,
      byInsuredTC: null,
      byInsuredName: null,
      byInsuredSurname: null,
      byOfferNumber: null,
      byPolicyNumber: null,
      byOfferStatus: null,
      byPolicyStatus: null,
    });
    this.offerStatus = [
      {
        name: 'Ürün Seçiliyor',
        value: OfferStatus.productSelection.valueOf(),
      },
      {
        name: 'Ödeme Tipi Seçiliyor',
        value: OfferStatus.installmentSelection.valueOf(),
      },
      {
        name: 'Ödeme Bekleniyor',
        value: OfferStatus.paymentPending.valueOf(),
      },
      {
        name: 'Sigortalı Ekleniyor',
        value: OfferStatus.insurerAdding.valueOf(),
      },
    ];
    this.policyStatus = [
      {
        name: 'Aktif',
        value: PolicyStatus.active.valueOf(),
      },
      {
        name: 'Pasif',
        value: PolicyStatus.passive.valueOf(),
      },
    ];
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
  }

  ngOnInit(): void {}

  search() {
    this.results = [];
    const filtered: any = {};
    for (let key in this.formGroup.value) {
      if (this.formGroup.value[key]) {
        filtered[key] = this.formGroup.value[key];
      }
    }
    this.apiOffer.Search(filtered).subscribe((x) => {
      console.log(x);
      for(let offer of x.data) {
        this.results.push({
          customer: offer.customer
        })
      }
    });
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
