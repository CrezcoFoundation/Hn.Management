import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { User } from '../interfaces/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = environment.api_url;
  userBase = '/api/User/';
  constructor( private http: HttpClient ) { }

  getAll() {
    return this.http.get<User[]>(`${this.baseUrl}${this.userBase}all`);
  }

  createUser( user: User ){
    return this.http.post<any>(`${this.baseUrl}${this.userBase}create`, user);
  }
}
