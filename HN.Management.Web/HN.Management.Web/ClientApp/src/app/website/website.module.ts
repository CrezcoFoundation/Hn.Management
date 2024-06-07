import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
// Custom imports
import { AppRoutingModule } from '../app-routing.module';
import { ContactUsModule } from 'src/app/website/contact-us/contact-us.module';
import { CrezcoStoryModule } from 'src/app/website/crezco-story/crezco-story.module';
import { GiveModule } from 'src/app/website/give/give.module';
import { HomeModule } from 'src/app/website/home/home.module';
import { SharedModule } from '../shared/shared.module';
import { WebSiteComponent } from './website.component';
import { WebSiteRoutingModule } from './website-routing.module';
// Language imports
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/locales/', '.translation.json');
}

@NgModule({
  declarations: [
    WebSiteComponent
  ],
  imports: [
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    AppRoutingModule,
    BrowserModule,
    CommonModule,
    ContactUsModule,
    CrezcoStoryModule,
    FormsModule,
    GiveModule,
    HomeModule,
    ReactiveFormsModule,
    SharedModule,
    WebSiteRoutingModule,
  ],
  exports: [
    WebSiteComponent
  ],
  bootstrap: [WebSiteComponent]
})
export class WebSiteModule { }
