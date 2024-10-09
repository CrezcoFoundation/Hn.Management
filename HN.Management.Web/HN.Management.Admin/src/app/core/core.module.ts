import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { LoginComponent } from '../features/login/login.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AddUserComponent } from './components/add-user/add-user.component';


@NgModule({
  declarations: [
    FooterComponent,
    HeaderComponent,
    SidebarComponent,
    LoginComponent,
    PageNotFoundComponent,
    AddUserComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [
    FooterComponent,
    HeaderComponent,
    SidebarComponent,
    LoginComponent,
    PageNotFoundComponent,
    AddUserComponent
  ]
})
export class CoreModule { }
