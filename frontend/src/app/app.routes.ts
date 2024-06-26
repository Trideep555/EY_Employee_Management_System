import { Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { HomeComponent } from './home/home.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { StudentsComponent } from './students/students.component';
import { NotfoundComponent } from './notfound/notfound.component';

export const routes: Routes = [
    {path:"", pathMatch:"full",component:HomeComponent},
    {path:"about",component:AboutComponent},
    {path:"contact",component:ContactComponent},
    {path:"login",component:LoginComponent},
    {path:"employee",component:StudentsComponent},
    {path:"**",component:NotfoundComponent}
    
];
