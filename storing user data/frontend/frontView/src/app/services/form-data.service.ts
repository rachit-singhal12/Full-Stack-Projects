import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FormDataService {
  url='https://localhost:7133/';
  constructor(private http : HttpClient) { }

  getMessage()
  {
    return this.http.get(this.url+'getMessage',{responseType: 'text'});
  }

  getUserData(data:any)
  {
    return this.http.post(this.url+'getUserData',data);
  }
}
