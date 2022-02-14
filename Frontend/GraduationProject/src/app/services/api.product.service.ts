import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseUrl } from '../app.module';
import { Product } from '../models/product';
import { IResponse } from '../models/response';

@Injectable({
  providedIn: 'root',
})
export class ApiProductService {
  private readonly Url = `${BaseUrl}/Product`;
  constructor(private http: HttpClient) {}

  GetProducts(): Observable<IResponse<Array<Product>>> {
    return this.http.get<IResponse<Array<Product>>>(this.Url);
  }
}
