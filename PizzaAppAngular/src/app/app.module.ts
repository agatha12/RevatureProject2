import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PizzaComponent } from './pizza/pizza.component';
import { ToppingsService } from './services/toppings.service';
import { Topping } from './classes/topping';
import { Pizza } from './classes/pizza';
import { PizzaTopping } from './classes/pizza-topping';
import { Order } from './classes/order';
import { PizzaService } from './services/pizza.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomerComponent } from './customer/customer.component';
import { CustomerService } from './services/customer.service';
import { NavComponent } from './nav/nav.component';




@NgModule({
  declarations: [
    AppComponent,
    PizzaComponent,
    CustomerComponent,
    NavComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [ToppingsService, PizzaService, Topping, Pizza, PizzaTopping, Order, CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
