import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

// Custom imports from Projects Folder
import { HomeComponent } from './home.component';
import { SharedModule } from 'src/app/web-site/shared/shared.module';
//Sweet alert
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { ContactUsModule } from "../contact-us/contact-us.module";

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/locales/', '.translation.json');
}

@NgModule({
    declarations: [HomeComponent],
    exports: [HomeComponent],
    imports: [
        HttpClientModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [HttpClient]
            }
        }),
        SharedModule,
        RouterModule,
        CommonModule,
        ReactiveFormsModule,
        FormsModule,
        SweetAlert2Module,
        ContactUsModule
    ]
})

export class HomeModule {
}
