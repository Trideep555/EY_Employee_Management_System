import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterOutlet } from '@angular/router';
import { catchError } from 'rxjs/operators';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [HttpClientModule,FormsModule,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username: string = "";
  password: string = "";
  errorMessage: string = "";

  constructor(private http: HttpClient) { }

  login() {
    const apiUrl = 'http://localhost:5172/api/auth/login'; // Replace this with your actual API URL
    this.http.post(apiUrl, { username: this.username, password: this.password })
      .pipe(
        catchError(error => {
          console.error("Login failed:", error);
          this.errorMessage = error.message;
          throw error;
        })
      )
      .subscribe((response: any) => {
        // Assuming your backend returns a success status code and possibly a token
        // You can add logic here to handle the response, such as storing the token
        console.log("Login successful");
      });
  } 
}