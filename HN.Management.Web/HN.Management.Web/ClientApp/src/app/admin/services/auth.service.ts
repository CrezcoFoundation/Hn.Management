import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.api_url;
  loginBase = 'api/Auth/';
  constructor( private http:HttpClient) { }

  login(email: string, password: string){
    return this.http.post<any>(`${this.baseUrl}${this.loginBase}login`, {email,password})
    .pipe(
      map(user => {
          if (user && user.token) {
            localStorage.setItem('currentUser', JSON.stringify(user));
          }
          return user;
      })
    );
  }
}
