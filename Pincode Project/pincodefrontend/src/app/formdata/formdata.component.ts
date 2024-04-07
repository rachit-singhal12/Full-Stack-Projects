import { Component } from '@angular/core';
import { DataServiceService } from '../services/data-service.service';
import { FormSchema } from '../classes/form-schema';
import { Router } from '@angular/router';

@Component({
  selector: 'app-formdata',
  templateUrl: './formdata.component.html',
  styleUrls: ['./formdata.component.css']
})
export class FormdataComponent {
  userList: FormSchema = new FormSchema();
  constructor(private service : DataServiceService, private route : Router) {} 

  userListDataBase:any[]=[]
  ngOnInit()
  {
    this.userList.status = "fetchusers";
    this.service.getUserData(this.userList).subscribe((response:any)=>{
      this.userListDataBase = response.Table;
    })
  }
  user:any;
  deleteUserData(data:any)
  {
    this.user = {id : data,status : "deleteuser"};
    this.service.getData(this.user).subscribe((response:any)=>{
      this.userListDataBase = response.Table;
    })
}

ChangeActiveState(data:any)
{
  this.user = {id : data,status : "changeActivestateofuser"};
    this.service.getData(this.user).subscribe((response:any)=>{
      this.userListDataBase = response.Table;
    })
}
}
