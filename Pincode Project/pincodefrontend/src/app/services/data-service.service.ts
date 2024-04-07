import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class DataServiceService {
  url='https://localhost:7256/';
  constructor(private http : HttpClient) { }

  getRequest()
  {
    return this.http.get(this.url+'getRequest',{responseType:'text'});
  }

  getData(data:any)
  {
    return this.http.post(this.url+'GetPinCodeData',data);
  }

  getUserData(data:any)
  {
    return this.http.post(this.url+'GetUserData',data);
  }
}
