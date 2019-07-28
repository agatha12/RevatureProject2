import { Component, OnInit } from '@angular/core';
import { Topping } from '../classes/topping';
import { ToppingsService } from '../services/toppings.service';

@Component({
  selector: 'app-pizza',
  templateUrl: './pizza.component.html',
  styleUrls: ['./pizza.component.css']
})
export class PizzaComponent implements OnInit {

  toppings: object;

  constructor(private topping: Topping, private topSrv: ToppingsService) { }

  ngOnInit() {
    this.topSrv.getToppings()
    .subscribe(data => {
      this.toppings = data;
      console.log(data)
    })

  }


}
