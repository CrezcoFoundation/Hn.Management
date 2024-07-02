import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Privilege } from '../interfaces/privilege';

@Injectable({
  providedIn: 'root'
})
export class PrivilegeService {

  baseUrl = environment.api_url;
  userBase = '/api/Identity/';
  constructor( private http: HttpClient ) { }

  getAll() {
    return this.http.get<Privilege[]>(`${this.baseUrl}${this.userBase}privileges`);
  }

  get( id: string ) {
    return this.http.get<Privilege[]>(`${this.baseUrl}${this.userBase}privileges/${id}`);
  }

  create( privilege: Privilege ){
    return this.http.post<any>(`${this.baseUrl}${this.userBase}privileges`, privilege);
  }

  update( privilege: Privilege ){
    return this.http.put<any>(`${this.baseUrl}${this.userBase}privileges`, privilege);
  }

  delete( id: string ){
    return this.http.delete<any>(`${this.baseUrl}${this.userBase}privileges/${id}`);
  }
}
