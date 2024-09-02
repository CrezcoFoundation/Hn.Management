import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { User } from '../interfaces/user';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private userSubject: BehaviorSubject<User | null> | undefined;
  public user: Observable<User | null> | undefined;
  public accessToken: string = ''

  baseUrl = environment.api_url;
  loginBase = '/api/Auth/';
  constructor
  ( 
    private http:HttpClient, 
    private router: Router
  ) 
  { 
    
  }

  public get userValue(){
    return this.userSubject!.value;
  }

  public get GetAccessToken(){
    return this.accessToken;
  }
  
  private SetAccessToken( _accessToken: string ){
    this.accessToken = _accessToken;
    return this.accessToken;
  }

  
  login(email: string, password: string){
    return this.http.post<any>(`${this.baseUrl}${this.loginBase}login`, {email,password})
    .pipe(
      map(user => {        
          if (user) {
            //this.startRefreshTokenTimer();
            // store user details and basic auth credentials in local storage to keep user logged in between page refreshes
            user.authdata = window.btoa(`${email} : ${password}`);
            localStorage.setItem('currentUser', user.accessToken);
            this.SetAccessToken(user.accessToken);
            const helper = new JwtHelperService();
            const decoded = helper.decodeToken(user.accessToken);
            this.userSubject = new BehaviorSubject(decoded);
            this.user = this.userSubject.asObservable();
            console.log(`decoded: ${decoded.value}`);
          }
          return user;
      })
    );
  }

  // logout
 logout(){
      // remove user from local storage
      localStorage.removeItem('currentUser');
      this.stopRefreshTokenTimer();
      this.router.navigate(['auth/login']);
  }

  refreshToken() {
    return this.http.post<any>(`${this.baseUrl}${this.loginBase}refresh-token`, {}, { withCredentials: true })
        .pipe(map((user) => {
            this.userSubject!.next(user);
            this.startRefreshTokenTimer();
            return user;
        }));
  }

    // helper methods

    private refreshTokenTimeout?: NodeJS.Timeout;

    private startRefreshTokenTimer(){
      // parse json object from base64 encoded jwt token
      const jwtBase64 = this.userValue!.jwtToken!.split('.')[1];
      const jwtToken = JSON.parse(atob(jwtBase64));

      // set a timeout to refresh the token a minute before it expires
      const expires = new Date(jwtToken.exp * 1000);
      const timeout = expires.getTime() - Date.now() - (60 * 1000);
      this.refreshTokenTimeout = setTimeout(() => this.refreshToken().subscribe(), timeout);
    }

    private stopRefreshTokenTimer() {
      clearTimeout(this.refreshTokenTimeout);
  }
}
