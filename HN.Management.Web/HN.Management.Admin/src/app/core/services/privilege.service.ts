import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core'; 
import { Privilege } from '../interfaces/privilege';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrivilegeService {

  baseUrl = environment.api_url;
  userBase = '/api/Identity/';
  constructor( private http: HttpClient ) { }

  getAll() {
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${localStorage.getItem('currentUser')}`
    });
    return this.http.get<Privilege[]>(`${this.baseUrl}${this.userBase}privileges`, { headers: httpHeaders });
  }

  get( id: string ) {
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${localStorage.getItem('currentUser')}`
    });
    return this.http.get<Privilege>(`${this.baseUrl}${this.userBase}privileges/${id}`, { headers: httpHeaders });
  }

  create( privilege: Privilege ){
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${localStorage.getItem('currentUser')}`
    });
    return this.http.post<any>(`${this.baseUrl}${this.userBase}privileges`, privilege, { headers: httpHeaders });
  }

  update( privilege: Privilege ){
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${localStorage.getItem('currentUser')}`
    });
    return this.http.put<any>(`${this.baseUrl}${this.userBase}privileges`, privilege, { headers: httpHeaders });
  }

  delete( id: string ){
    const httpHeaders: HttpHeaders = new HttpHeaders({
      Authorization: `Bearer ${localStorage.getItem('currentUser')}`
    });
    return this.http.delete<any>(`${this.baseUrl}${this.userBase}privileges/${id}`, { headers: httpHeaders });
  }
}
