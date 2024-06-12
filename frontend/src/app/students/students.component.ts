import { Component } from '@angular/core';
import { FooterComponent } from '../footer/footer.component';
import { HttpClient, HttpClientModule, HttpHeaders } from '@angular/common/http';
import { Student } from '../Student';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { AddStudent } from '../AddStudent';

@Component({
  selector: 'app-students',
  standalone: true,
  imports: [FooterComponent,HttpClientModule,CommonModule,FormsModule],
  templateUrl: './students.component.html',
  styleUrl: './students.component.css'
})
export class StudentsComponent {
  mydata:Observable<Student[]> | undefined;
  AddData : AddStudent ={
    name:"",
    email:"",
    department:"",
    phone:"",
    address:""
  };
  EditData : Student ={
    id: 0,
    name:"",
    email:"",
    department:"",
    phone:"",
    address:""
  };
  DeleteData: number =0;
  constructor(private http:HttpClient){
   this.mydata=this.http.get<Student[]>("http://localhost:5172/api/Employees");
   
  }
  HandleSubmit():void{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*' // This should be set on the server-side
    });
    
    this.http.post<Student>("http://localhost:5172/api/Employees",this.AddData,{headers: headers}).subscribe(data => {
     window.location.reload();
  })
  }
  HandleEdit(user:Student){
      this.EditData=user;
  }
  HandleEditSubmit():void{
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*' // This should be set on the server-side
    });
    
    this.http.put<Student>(`http://localhost:5172/api/Employees/${this.EditData.id}`,this.EditData,{headers: headers}).subscribe(data => {
     window.location.reload();
  })
  this.EditData  ={
    id: 0,
    name:"",
    email:"",
    department:"",
    phone:"",
    address:""
  };
  
}
  
  HandleDeleteSubmit(user:Student){
    this.DeleteData=user.id;
  }
  HandleEditDelete(){
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*' // This should be set on the server-side
    });
    this.http.delete<Student>(`http://localhost:5172/api/Employees/${this.DeleteData}`,{headers: headers}).subscribe(data => {
      window.location.reload();
   })
   this.DeleteData=0;
  }
  Search(value:string){
    if(value==""){
      this.mydata=this.http.get<Student[]>("http://localhost:5172/api/Employees");
    }
    else{
      this.mydata=this.http.get<Student[]>(`http://localhost:5172/api/employees/search?keyword=${value}`);
      
    }
  }
}
