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


@NgModule({
  declarations: [
    AppComponent,
    PizzaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [ToppingsService, PizzaService, Topping, Pizza, PizzaTopping, Order],
  bootstrap: [AppComponent]
})
export class AppModule { }
