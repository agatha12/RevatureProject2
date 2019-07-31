import { Component, OnInit } from '@angular/core';
import { Topping } from '../classes/topping';
import { ToppingsService } from '../services/toppings.service';
import { getLocaleEraNames } from '@angular/common';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-pizza',
  templateUrl: './pizza.component.html',
  styleUrls: ['./pizza.component.css']
})
export class PizzaComponent implements OnInit {

  pizzaForm: FormGroup;
  toppings: object;
  size: string;
  submitted = false;
  success = false;

  constructor(private topping: Topping, private topSrv: ToppingsService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.topSrv.getToppings()
    .subscribe(data => {
      this.toppings = data;
      console.log(data)
    })

    this.pizzaForm = this.formBuilder.group({
      size:['', Validators.required],
      topping: []
    });
  }

  onSubmit(){
    console.log(this.pizzaForm.value)
    this.submitted = true;
    if(this.pizzaForm.invalid){
      return;
    }
    this.success = true;

    

  }




}