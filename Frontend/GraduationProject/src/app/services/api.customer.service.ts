import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BaseUrl } from '../app.module';
import { Customer } from '../models/Customer';
import { IResponse } from '../models/response';

@Injectable({
  providedIn: 'root',
})
export class ApiCustomerService {
  private readonly Url = `${BaseUrl}/Customer`;
  constructor(private http: HttpClient) {}

  addCustomer(data: Customer): Observable<IResponse<Customer>> {
    return this.http.post<IResponse<Customer>>(this.Url, data);
  }
}
