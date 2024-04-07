import { Component } from '@angular/core';
import { DataServiceService } from './services/data-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'pincodefrontend';
  constructor(private service : DataServiceService){
    this.service.getRequest().subscribe((response:any)=>{
      console.log(response);
    })
  }

}
