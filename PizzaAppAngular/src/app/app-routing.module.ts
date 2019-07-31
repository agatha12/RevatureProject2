import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PizzaComponent } from './pizza/pizza.component';
import { CustomerComponent } from './customer/customer.component';


const routes: Routes = [
  {path: "pizza", component: PizzaComponent},
  {path: "customer", component: CustomerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
