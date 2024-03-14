import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from 'src/app/web-site/shared/shared.module';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ContactUsComponent } from './contact-us/contact-us.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/locales/', '.translation.json');
}
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
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
  ],
  exports: [ContactUsComponent],
})
export class ContactUsModule {}
