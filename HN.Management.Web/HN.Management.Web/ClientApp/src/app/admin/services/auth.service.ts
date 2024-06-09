import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map, retry } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private userSubject: BehaviorSubject<User | null>;
  public user: Observable<User | null>;
  private isNavFooter: boolean = true;

  baseUrl = environment.api_url;
  loginBase = '/api/Auth/';
  constructor
  ( 
    private http:HttpClient, 
    private router: Router
  ) 
  { 
    this.userSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('currentUser')!));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(){
    return this.userSubject.value;
  }

  public setIsNavFooter(_isNavFooter: boolean){
    return this.isNavFooter = _isNavFooter;
  }

  public get getIsNavFooter(){
    return this.isNavFooter;
  }

  login(email: string, password: string){
    return this.http.post<any>(`${this.baseUrl}${this.loginBase}login`, {email,password})
    .pipe(
      map(user => {
          if (user && user.token) {
            // store user details and basic auth credentials in local storage to keep user logged in between page refreshes
            user.authdata = window.btoa(`${email} : ${password}`);
            localStorage.setItem('currentUser', JSON.stringify(user));
            this.userSubject.next(user);
          }
          return user;
      })
    );
  }

  // logout
    logout(){
        // remove user from local storage
        localStorage.removeItem('currentUser');
        this.userSubject.next(null);
        this.router.navigate(['auth/login']);
    }
}
