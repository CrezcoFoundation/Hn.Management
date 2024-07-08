import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Role } from '../interfaces/role';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  baseUrl = environment.api_url;
  userBase = '/api/Identity/';
  constructor( private http: HttpClient, private authService: AuthService ) { }

  getAll() {
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.GetAccessToken}`
    });
    return this.http.get<Role[]>(`${this.baseUrl}${this.userBase}roles`, { headers: httpHeaders });
  }

  getById( id: string ) {
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.GetAccessToken}`
    });
    return this.http.get<Role[]>(`${this.baseUrl}${this.userBase}roles/${id}`, { headers: httpHeaders });
  }

  create( role: Role ){
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.GetAccessToken}`
    });
    return this.http.post<any>(`${this.baseUrl}${this.userBase}roles`, role, { headers: httpHeaders });
  }

  update( role: Role ){
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.GetAccessToken}`
    });
    return this.http.put<any>(`${this.baseUrl}${this.userBase}roles`, role, { headers: httpHeaders });
  }

  delete( id: string ){
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${this.authService.GetAccessToken}`
    });
    return this.http.delete<any>(`${this.baseUrl}${this.userBase}roles/${id}`, { headers: httpHeaders });
  }
  
}
