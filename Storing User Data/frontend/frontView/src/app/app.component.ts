import { Component } from '@angular/core';
import { FormDataService } from './services/form-data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontView';
  message:any;
  userList:any[]=[];
  constructor(private user : FormDataService){}

  ngOnInit()
  {
    this.user.getMessage().subscribe(response=>{
      this.message = response;
    })
  }

  getUserAllData(data:any)
  {
    if(data.name=='')
    {
      data.name = "null";
      data.email = "null";
      data.password = "null";
      data.id = 0;
    }

    this.userList.push(data);
    let obj = { Users:this.userList }

    this.user.getUserData(obj).subscribe((response:any)=>{
      console.log(response);
    })
  }
}
