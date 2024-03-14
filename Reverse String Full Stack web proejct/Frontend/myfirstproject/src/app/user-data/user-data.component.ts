import { Component } from '@angular/core';
import { MyfirstserviceService } from '../services/myfirstservice.service';
@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrl: './user-data.component.css'
})
export class UserDataComponent {
  usersData:any;
  name:any;
  status:any;
  constructor(private http : MyfirstserviceService){}
  getUserAllData(data:any)
  {
    this.usersData = data;
    console.warn( this.usersData);
    this.http.setUserData(this.usersData).subscribe((response:any)=>{
      console.log(response)
    
      localStorage.setItem("User" , JSON.stringify(response) )
      this.name = response.reversedName;
      if(response.successmeaggae)
      {
        this.status = response.successmeaggae;
      }
      else{
        this.status = response.errormeaggae;
      }
    }) 
  }
 

}
