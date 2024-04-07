export class FormSchema {
  name: string;
  email: string;
  dateOfBirth: Date;
  age: number;
  gender: string;
  hobbies: string;
  state: number;
  district: number;
  city: number;
  pincode: number;
  status : string;
  statename:string;
  districtname : string;
  cityname:string;

  constructor() {
    this.name = '';
    this.email = '';
    this.dateOfBirth = new Date(11-11-1111);
    this.age = 0;
    this.gender = '';
    this.hobbies = '';
    this.state = 0;
    this.district = 0;
    this.city = 0;
    this.pincode = 0;
    this.status = '';
    this.statename ='';
    this.districtname = '';
    this.cityname = '';
  }
}
