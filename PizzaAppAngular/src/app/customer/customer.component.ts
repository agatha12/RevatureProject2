import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../services/customer.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {

  customers: object;
  customer: object;
  customerForm: FormGroup;
  submitted = false;
  success = false;

  constructor(private custSrv: CustomerService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.customerForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit(){
    this.submitted = true;
    if(this.customerForm.invalid){
      return;
    }
    this.success = true;
    this.getCustomerByEmail(this.customerForm.value.email)
  }

  getCustomers(){
    this.custSrv.getCustomers()
    .subscribe(data =>{
      this.customers = data;
      console.log(data)
    })

  }

  getCustomerByEmail(email){
    
    this.custSrv.getCustomerByEmail(email)
    .subscribe(data => {
      this.customer = data;
      console.log(data)
      if(data.password === this.customer.password){
        console.log("yes")
        localStorage.setItem("id", data.id)
        console.log(localStorage.getItem("id"))
      }
      else{

        console.log("no")
      }
      
    })
  }

}
