import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from 'src/shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [ContactUsComponent],
  imports: [
    ReactiveFormsModule,
    CommonModule,
    SharedModule,
    FormsModule,
    BrowserModule,
    SweetAlert2Module,
    HttpClientModule,
  ],
  exports: [ContactUsComponent],
})
export class ContactUsModule {}
