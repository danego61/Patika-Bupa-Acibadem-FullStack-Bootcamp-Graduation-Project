import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagementComponent } from './components/management/management.component';
import { InsuredComponent } from './components/registration/pages/insured/insured.component';
import { InsurerComponent } from './components/registration/pages/insurer/insurer.component';
import { PaymentComponent } from './components/registration/pages/payment/payment.component';
import { PremiumComponent } from './components/registration/pages/premium/premium.component';
import { ProductComponent } from './components/registration/pages/product/product.component';
import { RegistrationComponent } from './components/registration/registration.component';

const routes: Routes = [
  {
    path: 'registration',
    component: RegistrationComponent,
    children: [
      { path: 'insured', component: InsuredComponent },
      { path: ':id/insurer', component: InsurerComponent },
      { path: ':id/payment', component: PaymentComponent },
      { path: ':id/premium', component: PremiumComponent },
      { path: ':id/product', component: ProductComponent },
      { path: '**', redirectTo: 'insured' },
    ],
  },
  { path: 'management', component: ManagementComponent },
  { path: '**', redirectTo: 'registration' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
