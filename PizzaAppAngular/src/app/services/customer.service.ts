import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from '../classes/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  getCustomers(){
    
    return this.http.get("http://localhost:56766/api/customers");
  }

  getCustomer(id){
    
    return this.http.get("http://localhost:56766/api/customers"+id);
  }

  getCustomerByEmail(email: string){
    return this.http.get("http://localhost:56766/api/customers/GetByEmail/"+email);
  }

  post(customer: Customer){

    return this.http.post("http://localhost:56766/api/customers", customer);

  }

  update(id: number, customer: Customer){

    return this.http.put("http://localhost:56766/api/customers"+id, customer)
  }

  delete(id: number){

    return this.http.delete("http://localhost:56766/api/customers"+id)

  }
}
