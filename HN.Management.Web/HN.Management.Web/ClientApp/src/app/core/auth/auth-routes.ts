import { Routes } from '@angular/router';
import { LoginComponent } from 'src/app/core/auth/login/login.component';
import { ForgotComponent } from 'src/app/core/auth/forgot/forgot.component';
import { RegisterComponent } from './register/register.component';

export const AuthRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'forgot', component: ForgotComponent },
  { path: 'register', component: RegisterComponent },
];
