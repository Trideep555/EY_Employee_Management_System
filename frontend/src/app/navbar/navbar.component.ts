import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterOutlet,CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  isLogin : boolean = false;
  ngOnInit(){
    if(window.localStorage.length!=0){
    if(localStorage.getItem("admin")!==null){
      this.isLogin=true;
    }
  }
  }
  Logout(){
    localStorage.clear();
    window.location.pathname="/";
  }
}
