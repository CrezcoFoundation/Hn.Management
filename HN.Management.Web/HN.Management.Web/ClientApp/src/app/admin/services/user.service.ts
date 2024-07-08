import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../interfaces/user';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  baseUrl = environment.api_url;
  userBase = '/api/User/';
  
  constructor( private http: HttpClient, private authService: AuthService ) { }

  getAll() {
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.GetAccessToken}`
    });
    return this.http.get<User[]>(`${this.baseUrl}${this.userBase}all`, { headers: httpHeaders });
  }

  create( user: User ){
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.GetAccessToken}`
    });
    return this.http.post<any>(`${this.baseUrl}${this.userBase}create`, user, { headers: httpHeaders });
  }

  update( user: User ){
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.GetAccessToken}`
    });
    return this.http.put<any>(`${this.baseUrl}${this.userBase}update`, user, { headers: httpHeaders });
  }

  getById(id: string){
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.GetAccessToken}`
    });
    return this.http.get<User[]>(`${this.baseUrl}${this.userBase}user/${id}`, { headers: httpHeaders })
  }
}
