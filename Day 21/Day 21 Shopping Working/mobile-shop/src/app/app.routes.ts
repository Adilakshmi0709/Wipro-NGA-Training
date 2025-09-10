import { Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list';
import { BillingComponent } from './billing/billing';
import { ThankYouComponent } from './thank-you/thank-you';

export const routes: Routes = [
  { path: '', component: ProductListComponent },
  { path: 'billing', component: BillingComponent },
  { path: 'thank-you', component: ThankYouComponent }
];