import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Pizza } from '../classes/pizza'

@Injectable({
  providedIn: 'root'
})
export class PizzaService {

  constructor(private http: HttpClient) { }

  getPizzas(){
    
    return this.http.get("http://localhost:56766/api/pizzas");
  }

  getPizza(id){
    
    return this.http.get("http://localhost:56766/api/pizzas"+id);
  }

  postPizza(pizza: Pizza){

    return this.http.post("http://localhost:56766/api/pizzas", pizza);

  }

  updatePizza(id: number, pizza: Pizza){

    return this.http.put("http://localhost:56766/api/pizzas"+id, pizza)
  }

  deletePizza(id: number){

    return this.http.delete("http://localhost:56766/api/pizzas"+id)

  }

}
