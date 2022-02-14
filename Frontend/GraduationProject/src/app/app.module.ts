import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule  } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { ManagementComponent } from './components/management/management.component';

import { StepsModule } from 'primeng/steps';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import {InputMaskModule} from 'primeng/inputmask';
import {InputNumberModule} from 'primeng/inputnumber';
import {TableModule} from 'primeng/table';
import {RadioButtonModule} from 'primeng/radiobutton';

import { InsuredComponent } from './components/registration/pages/insured/insured.component';
import { InsurerComponent } from './components/registration/pages/insurer/insurer.component';
import { ProductComponent } from './components/registration/pages/product/product.component';
import { PremiumComponent } from './components/registration/pages/premium/premium.component';
import { PaymentComponent } from './components/registration/pages/payment/payment.component';

export const BaseUrl: string = 'http://localhost:5081/api';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    ManagementComponent,
    InsuredComponent,
    InsurerComponent,
    ProductComponent,
    PremiumComponent,
    PaymentComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    StepsModule,
    InputTextModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonModule,
    DropdownModule,
    BrowserAnimationsModule,
    InputMaskModule,
    InputNumberModule,
    TableModule,
    RadioButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
