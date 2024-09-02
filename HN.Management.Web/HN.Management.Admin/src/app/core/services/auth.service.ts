import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core'; 
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { User } from '../interfaces/user';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from '../../../environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedIn = new BehaviorSubject<boolean>(false);
  private userSubject: BehaviorSubject<User | null> | undefined;
  public user: Observable<User | null> | undefined;

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

  get isLoggedIn() {
    if(localStorage.getItem('currentUser')){
      this.loggedIn.next(true);
    }
    return this.loggedIn.asObservable();
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
            const helper = new JwtHelperService();
            const decoded = helper.decodeToken(user.accessToken);
            this.userSubject = new BehaviorSubject(decoded);
            this.user = this.userSubject.asObservable();
            this.loggedIn.next(true);
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
      this.loggedIn.next(false);
      this.stopRefreshTokenTimer();
      this.router.navigate(['/login']);
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

    //private refreshTokenTimeout?: NodeJS.Timeout;

    private startRefreshTokenTimer(){
      // parse json object from base64 encoded jwt token
      const jwtBase64 = this.userValue!.jwtToken!.split('.')[1];
      const jwtToken = JSON.parse(atob(jwtBase64));

      // set a timeout to refresh the token a minute before it expires
      const expires = new Date(jwtToken.exp * 1000);
      const timeout = expires.getTime() - Date.now() - (60 * 1000);
      //this.refreshTokenTimeout = setTimeout(() => this.refreshToken().subscribe(), timeout);
    }

    private stopRefreshTokenTimer() {
      //clearTimeout(this.refreshTokenTimeout);
  }
}
