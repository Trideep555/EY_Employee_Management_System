import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterOutlet } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { Admin } from '../Admin';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [HttpClientModule,FormsModule,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  Admin: Admin={
    username:"",
    password:""
  };
  errorMessage: string = "";

  constructor(private http: HttpClient) { }

  Login():void{
   
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*' // This should be set on the server-side
    });
    
    this.http.post<Admin>("http://localhost:5172/api/auth/login",this.Admin,{headers: headers}).subscribe(data => {
      window.localStorage.setItem("admin","true"); 
    window.location.pathname="/employee";
    
  },(error)=>{
    this.errorMessage="Wrong Username or Password";
  })
  } 
}