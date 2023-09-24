import { Routes } from '@angular/router';
import { LoginComponent } from 'src/auth/login/login.component';
import { ForgotComponent } from 'src/auth/forgot/forgot.component';
import { RegisterComponent } from './register/register.component';

export const AuthRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'forgot', component: ForgotComponent },
  { path: 'register', component: RegisterComponent },
];
