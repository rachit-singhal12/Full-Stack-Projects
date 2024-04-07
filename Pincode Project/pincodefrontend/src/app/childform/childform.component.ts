import { Component, Input } from '@angular/core';
import { DataServiceService } from '../services/data-service.service';

@Component({
  selector: 'app-childform',
  templateUrl: './childform.component.html',
  styleUrls: ['./childform.component.css']
})

export class ChildformComponent {
  constructor(private service: DataServiceService ) { }
  stateList: any[] = [];
  districtList: any[] = [];
  cityList: any[] = [];
  pincodeList: any[] = [];

  data: {
    status: string,
    id: number,
    id2 : number
  } = {
      status: "state",
      id: 0,
      id2 : 0
  }


  selectedStateid: number = 0;
  selectedDistrictid: number = 0;
  selectedCityid: number = 0;
  selectedPincodeid: number = 0;
  statename: string = '';
  districtname: string = '';
  cityname: string = '';

  @Input() childInput: any;


  ngOnInit() {    
    this.data.status = "state";
    this.data.id = 0;
    this.service.getData(this.data).subscribe((response: any) => {
      this.stateList = response.Table;

      if(this.childInput.state!=0 && this.childInput.district!=0 && this.childInput.city!=0 && this.childInput.pincode!=0)
      {
        this.selectedStateid = this.childInput.state;

        this.data.status = 'district';
        this.data.id = this.childInput.state;
        this.service.getData(this.data).subscribe((response: any) => {
          this.districtList = response.Table;
          
          this.selectedDistrictid = this.childInput.district;
          this.data.status = 'city';
          this.data.id = this.childInput.district;

          this.service.getData(this.data).subscribe((response: any) => {
            this.cityList = response.Table;

            this.selectedCityid = this.childInput.city;
            this.data.status = 'pincode';
            this.data.id = this.childInput.state;
            this.data.id2 = this.childInput.district;

            this.service.getData(this.data).subscribe((response: any) => {
              this.selectedPincodeid = this.childInput.pincode;
              this.pincodeList = response.Table;
            })
          })
        })
      }
    })
  }

  SaveChanges() {
    this.CloseModal();
  }

  getState(data: any) {
    this.selectedStateid = data;
    this.selectedDistrictid = 0;
    this.selectedCityid = 0;
    this.selectedPincodeid = 0;


    let filteredStates = this.stateList.filter(state => state.StateId == this.selectedStateid);
    this.statename = filteredStates[0].StateName;
    this.childInput.state = this.selectedStateid;
    this.childInput.statename = this.statename;
    this.data.status = 'district';
    this.data.id = data;
    this.service.getData(this.data).subscribe((response: any) => {
      this.districtList = response.Table;
    })
    this.data.status = '';
    this.data.id = 0;
  }

  getDistrict(data: any) {
    this.selectedDistrictid = data;
    this.selectedCityid = 0;
    this.selectedPincodeid = 0;
    let filteredDistrict = this.districtList.filter(state => state.DistrictId == this.selectedDistrictid);
    this.districtname = filteredDistrict[0].DistrictName;
    this.childInput.district = this.selectedDistrictid;
    this.childInput.districtname = this.districtname;
    this.data.status = 'city';
    this.data.id = data;
    this.service.getData(this.data).subscribe((response: any) => {
      this.cityList = response.Table;
    })
    this.data.status = '';
    this.data.id = 0;
  }

  getCity(data: any) {
    this.selectedCityid = data;
    this.selectedPincodeid = 0;

    let filteredcity = this.cityList.filter(state => state.CityId == this.selectedCityid);
    this.cityname = filteredcity[0].CityName;
    this.childInput.city = this.selectedCityid;
    this.childInput.cityname = this.cityname;
    this.data.status = 'pincode';
    this.data.id = this.selectedStateid;
    this.data.id2 = this.selectedDistrictid;
    this.service.getData(this.data).subscribe((response: any) => {
      this.pincodeList = response.Table;
    })
    this.data.status = '';
    this.data.id = 0;
  }

  getPincode(data: any) {
    this.selectedPincodeid = data;
    this.childInput.pincode = this.selectedPincodeid;
  }

  CloseModal() {
    const modaldiv = document.getElementById('example');
    if (modaldiv != null) {
      modaldiv.style.display = 'none';
    }
  }
}
