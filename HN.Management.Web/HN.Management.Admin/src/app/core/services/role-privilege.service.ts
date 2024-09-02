import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { RolePrivilege, RolePrivilegeRequest } from '../interfaces/role-privilege';

@Injectable({
  providedIn: 'root'
})
export class RolePrivilegeService {

  baseUrl = environment.api_url;
  userBase = '/api/Identity/';
  constructor( private http: HttpClient ) { }

  getAll() {
    return this.http.get<RolePrivilege[]>(`${this.baseUrl}${this.userBase}role-privileges`);
  }

  get( id: string ) {
    return this.http.get<RolePrivilege[]>(`${this.baseUrl}${this.userBase}role-privileges/${id}`);
  }

  create( rolePrivilege: RolePrivilegeRequest ){
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${localStorage.getItem('currentUser')}`
    });
    return this.http.post<any>(`${this.baseUrl}${this.userBase}role-privileges`, rolePrivilege, { headers: httpHeaders });
  }

  update( rolePrivilege: RolePrivilege ){
    return this.http.put<any>(`${this.baseUrl}${this.userBase}role-privileges`, rolePrivilege);
  }

  delete( id: string ){
    return this.http.delete<any>(`${this.baseUrl}${this.userBase}role-privileges/${id}`);
  }
}
