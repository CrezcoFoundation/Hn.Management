import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
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
  declarations: [],
  imports: [
    ReactiveFormsModule,
    CommonModule,
    SharedModule,
    FormsModule,
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
  exports: [],
})
export class ContactUsModule {}
