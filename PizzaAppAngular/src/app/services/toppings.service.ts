import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ToppingsService {

  constructor(private http: HttpClient) { }

  getToppings(){
    
    return this.http.get("http://localhost:56766/api/toppings");
  }

}
