import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
// Custom imports
import { ContactUsModule } from 'src/app/website/contact-us/contact-us.module';
import { CrezcoStoryModule } from 'src/app/website/crezco-story/crezco-story.module';
import { HomeModule } from 'src/app/website/home/home.module';
import { SharedModule } from '../shared/shared.module';
import { WebSiteRoutingModule } from './website-routing.module';
// Language imports
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/locales/', '.translation.json');
}

@NgModule({
  declarations: [],
  imports: [
    HttpClientModule,
    CommonModule,
    ContactUsModule,
    CrezcoStoryModule,
    FormsModule,
    HomeModule,
    ReactiveFormsModule,
    SharedModule,
    WebSiteRoutingModule,
    TranslateModule.forChild({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
  ],
  exports: [],
  bootstrap: []
})
export class WebSiteModule { }
