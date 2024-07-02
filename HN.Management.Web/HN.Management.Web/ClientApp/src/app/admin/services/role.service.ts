import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Role } from '../interfaces/role';

@Injectable({
  providedIn: 'root'
})
export class RoleService {

  baseUrl = environment.api_url;
  userBase = '/api/Identity/';
  constructor( private http: HttpClient ) { }

  getAll() {
    return this.http.get<Role[]>(`${this.baseUrl}${this.userBase}roles`);
  }

  get( id: string ) {
    return this.http.get<Role[]>(`${this.baseUrl}${this.userBase}roles/${id}`);
  }

  create( role: Role ){
    return this.http.post<any>(`${this.baseUrl}${this.userBase}roles`, role);
  }

  update( role: Role ){
    return this.http.put<any>(`${this.baseUrl}${this.userBase}roles`, role);
  }

  delete( id: string ){
    return this.http.delete<any>(`${this.baseUrl}${this.userBase}roles/${id}`);
  }
  
}
