import { Component } from '@angular/core';
import { MyfirstserviceService } from '../services/myfirstservice.service';
@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrl: './child.component.css'
})
export class ChildComponent {
  name:any;
  constructor(private post : MyfirstserviceService)
  {  }
  ngOnInit()
  {
    this.post.getUserData().subscribe(response=>{
      this.name = response;
    })
  }
}
