import { Component } from '@angular/core';
import { DataService } from './Services/data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'FrontEnd';
  data = {
    id : 1
  };

  studentList : any;
  constructor(private user : DataService){}
  ngOnInit()
  {
    this.user.getRequest().subscribe((response:any)=>{
      console.log(response);
    })
  }
  getStudentData(d:any)
  {
    this.data.id = d;
    console.log(this.data)
    this.user.getAllData(this.data).subscribe((response:any)=>{
      this.studentList = response;
      console.log(response);
    });
  }
}
