import { Component } from '@angular/core';

@Component({
  selector: 'app-practice',
  templateUrl: './practice.component.html',
  styleUrls: ['./practice.component.css']
})
export class PracticeComponent {
  skillList:any[]=[];
  selectedSkills:any[]=[];
  constructor()
  {
    for(let i=0;i<10;i++)
    {
      this.skillList.push("skill"+i);
    }
    this.selectedSkills.push("skill0")
  }

  getSkills(data:any)
  {
    this.selectedSkills = data
    console.log(this.selectedSkills);
  }
}
