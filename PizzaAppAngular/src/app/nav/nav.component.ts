import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  customerId: string;

  constructor() { }

  ngOnInit() {
    console.log(localStorage.getItem("customerId"))
    this.customerId = localStorage.getItem("customerId")
  }
  logout(){
    localStorage.clear();
    console.log(localStorage.getItem("customerId"))
  }

}
