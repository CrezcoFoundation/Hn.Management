import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { AuthComponent } from './auth/auth.component';
import { AuthRoutingModule } from './auth-routing.module';
import { ForgotComponent } from './forgot/forgot.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [
    LoginComponent,
    AuthComponent,
    ForgotComponent,
    RegisterComponent,
  ],
  imports: [ReactiveFormsModule, CommonModule, AuthRoutingModule, FormsModule],
  bootstrap: [
    LoginComponent,
    AuthComponent,
    ForgotComponent,
    RegisterComponent,
  ],
})
export class AuthModule {}
