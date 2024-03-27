import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class DataService {
  url='https://localhost:7294/';
  constructor(private http : HttpClient) { }
  getRequest()
  {
    return this.http.get(this.url + 'getdemo',{responseType: 'text' })
  }
  getAllData(data:any)
  {
    return this.http.post(this.url + 'getsrtudentdata',data);
  }
}
