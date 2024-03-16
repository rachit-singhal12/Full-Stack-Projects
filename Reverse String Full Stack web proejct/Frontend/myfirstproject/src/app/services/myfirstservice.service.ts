import { HttpClient } from '@angular/common/http';
import { Injectable, } from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class MyfirstserviceService {
  url='https://localhost:7038/'
  constructor(private http : HttpClient) { }
  getUserData()
  {
    return this.http.get(this.url+'getData',{responseType:'text'});
  }
  setUserData(data:any)
  {
    return this.http.post(this.url+'postData' ,data );
  }
}
