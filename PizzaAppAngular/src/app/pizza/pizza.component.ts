import { Component, OnInit } from '@angular/core';
import { Topping } from '../topping';
import { ToppingsService } from '../toppings.service';

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
