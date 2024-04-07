import { Component } from '@angular/core';
import { FormSchema } from '../classes/form-schema';
import { DataServiceService } from '../services/data-service.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-parentform',
  templateUrl: './parentform.component.html',
  styleUrls: ['./parentform.component.css']
})

export class ParentformComponent {
  tempUserData: any;
  constructor(private service: DataServiceService, private route: Router, private param: ActivatedRoute) { }

  public isDataFetched: boolean = false;

  userClassData = new FormSchema();
  UserId: any;
  hobby1 = false;
  hobby2 = false;
  hobby3 = false;
  state = "";
  district = "";
  city = "";
  pincode = "";
   ngOnInit() {
    this.param.params.subscribe(params => {
      this.UserId = params['id'];
    });

    if (this.UserId) {
       this.service.getData({ status: "fetchsingleuser", id: this.UserId }).subscribe( (response: any) => {
        this.tempUserData = response.Table;
        if (this.tempUserData.length > 0) {
          this.userClassData.name = this.tempUserData[0].Name;
          this.userClassData.email = this.tempUserData[0].Email;
          this.userClassData.hobbies = this.tempUserData[0].Hobbies;
          this.userClassData.dateOfBirth = response.Table[0].DateOfBirth.split('T')[0];;
          this.userClassData.age = this.tempUserData[0].Age;
          this.userClassData.gender = this.tempUserData[0].Gender;
          this.userClassData.hobbies = this.tempUserData[0].Hobbies;
          this.userClassData.state = this.tempUserData[0].State;
          this.userClassData.district = this.tempUserData[0].District;
          this.userClassData.city = this.tempUserData[0].City;
          this.userClassData.pincode = this.tempUserData[0].Pincode;
          this.userClassData.status = this.tempUserData[0].Active;
          this.userClassData.statename = this.tempUserData[0].statename;
          this.userClassData.districtname = this.tempUserData[0].districtname;
          this.userClassData.cityname = this.tempUserData[0].cityname;
          let h = this.userClassData.hobbies;
          if (h) {
            let hobbiesArray = h.split(" ");
            for (let hobby of hobbiesArray) {
              if (hobby === "Reading") {
                this.hobby1 = true;
              } else if (hobby === "Traveling") {
                this.hobby2 = true;
              } else if (hobby === "Cooking") {
                this.hobby3 = true;
              }
            }
          }
          else {
            console.log("hobby is undefined");
          }
        }
        this.isDataFetched = true;
      });
    } else {
      this.userClassData.name = '';
      this.userClassData.email = '';
      this.userClassData.dateOfBirth = new Date('1111-11-11');
      this.userClassData.age = 0;
      this.userClassData.gender = '';
      this.userClassData.hobbies = 'H1-N,H2-N,H3-N';
      this.userClassData.state = 0;
      this.userClassData.district = 0;
      this.userClassData.city = 0;
      this.userClassData.pincode = 0;
      this.userClassData.status = 'N';
      this.userClassData.statename = '';
      this.userClassData.districtname = '';
      this.userClassData.cityname = '';
    }
  }
  opened = false;
  OpenModal() {
    this.opened = true;
    const modaldiv = document.getElementById('example');
    if (modaldiv != null) {
      modaldiv.style.display = 'block';
    }
  }



  getUserData(data: any) {
    let hobbies: string = "";
    if (this.hobby1) {
      hobbies += "H1-Y,";
    }
    else {
      hobbies += "H1-N,";
    }
    if (this.hobby2) {
      hobbies += "H2-Y,";
    }
    else {
      hobbies += "H2-N,";
    }
    if (this.hobby3) {
      hobbies += "H3-Y";
    }
    else {
      hobbies += "H3-N";
    }
    this.userClassData.hobbies = hobbies;
    if (this.UserId) {
      this.userClassData.status = "update user";
      let temp: any = { id: this.UserId, ...this.userClassData };
      this.service.getUserData(temp).subscribe((response: any) => {
      })
      this.route.navigateByUrl('/formdata');
    }
    else {
      this.userClassData.status = "save user";
      this.service.getUserData(this.userClassData).subscribe((response: any) => {
      })
      this.route.navigateByUrl('/formdata');
    }
  }
}
