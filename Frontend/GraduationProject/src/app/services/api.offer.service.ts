import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseUrl } from '../app.module';
import {
  AddOfferDetailModel,
  AddOfferModel,
  Offer,
  OfferUpdateProduct,
} from '../models/offer';
import { IResponse } from '../models/response';

@Injectable({
  providedIn: 'root',
})
export class ApiOfferService {
  private readonly Url = `${BaseUrl}/Offer`;
  constructor(private http: HttpClient) {}

  AddOffer(offer: AddOfferModel): Observable<IResponse<Offer>> {
    return this.http.post<IResponse<Offer>>(this.Url, offer);
  }

  AddOfferDetail(
    offerId: number,
    offerDetail: AddOfferDetailModel
  ): Observable<IResponse<null>> {
    return this.http.post<IResponse<null>>(
      `${this.Url}/${offerId}/addOfferDetail`,
      offerDetail
    );
  }

  CompleteAdding(offerId: number): Observable<IResponse<null>> {
    return this.http.post<IResponse<null>>(
      `${this.Url}/${offerId}/completeOfferDetail`,
      null
    );
  }

  GetOffer(offerId: number): Observable<IResponse<Offer>> {
    return this.http.get<IResponse<Offer>>(`${this.Url}/${offerId}`);
  }

  UpdateOfferProduct(
    offerId: number,
    data: any
  ): Observable<IResponse<OfferUpdateProduct>> {
    return this.http.post<IResponse<OfferUpdateProduct>>(
      `${this.Url}/${offerId}/updateProduct`,
      data
    );
  }

  UpdateOfferInstallment(
    offerId: number,
    data: any
  ): Observable<IResponse<null>> {
    return this.http.post<IResponse<null>>(
      `${this.Url}/${offerId}/updateInstallment`,
      data
    );
  }

  Search(data: any): Observable<IResponse<Array<Offer>>> {
    return this.http.get<IResponse<Array<Offer>>>(this.Url, { params: data });
  }
}
