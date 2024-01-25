import { NgModule,  APP_INITIALIZER, LOCALE_ID } from '@angular/core';
import { BrowserModule, Title } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

import { WebSiteRoutingModule } from './web-site-routing.module';
import { WebSiteComponent } from './web-site.component';
import { ContactUsModule } from 'src/app/web-site/contact-us/contact-us.module';
import { CrezcoStoryModule } from 'src/app/web-site/crezco-story/crezco-story.module';
import { GiveModule } from 'src/app/web-site/give/give.module';
import { HomeModule } from 'src/app/web-site/home/home.module';
import { SharedModule } from 'src/app/web-site/shared/shared.module';
import { AppRoutingModule } from '../app-routing.module';

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { I18NextModule, ITranslationService, I18NEXT_SERVICE, I18NextTitle, defaultInterpolationFormat } from 'angular-i18next';

// i18n Translate
import Backend from 'i18next-chained-backend';
import LanguageDetector from 'i18next-browser-languagedetector';

// Translation files
import en from '../../assets/locales/en.translation.json';
import el from '../../assets/locales/es.translation.json';

const resources = {
  en: {
    translation: en
  },
  el: {
    translation: el
  }
};

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/locales/', '.translation.json');
}

export function appInit(i18next: ITranslationService) {
  return () =>
      i18next
      .use(Backend)
      .use(LanguageDetector)
      .init({
      resources,
      supportedLngs: ['en', 'el'],
      fallbackLng: 'en',
      debug: true,
      returnEmptyString: false,
      defaultNS: "translation",
      ns: [
        'translation'
      ],
      interpolation: {
        format: I18NextModule.interpolationFormat(defaultInterpolationFormat)
      },
      backend: {
        loadPath: 'assets/locales/{{lng}}.{{ns}}.json',
      },
      // lang detection plugin options
      detection: {
        // order and from where user language should be detected
        order: ['querystring', 'cookie'],
        // keys or params to lookup language from
        lookupCookie: 'lang',
        lookupQuerystring: 'lng',
        // cache user language on
        caches: ['localStorage', 'cookie'],
        // optional expire and domain for set cookie
        cookieMinutes: 10080, // 7 days
      }
    });
}
export function localeIdFactory(i18next: ITranslationService)  {
  return i18next.language;
}
export const I18N_PROVIDERS = [
{
  provide: APP_INITIALIZER,
  useFactory: appInit,
  deps: [I18NEXT_SERVICE],
  multi: true
},
{
  provide: Title,
  useClass: I18NextTitle
},
{
  provide: LOCALE_ID,
  deps: [I18NEXT_SERVICE],
  useFactory: localeIdFactory
}];

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
    ContactUsModule,
    CrezcoStoryModule,
    GiveModule,
    HomeModule,
    SharedModule,
    CommonModule,
    WebSiteRoutingModule,
    FormsModule,
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    I18NextModule.forRoot()
  ],
  exports: [
    WebSiteComponent
  ],
  providers: [I18N_PROVIDERS],
  bootstrap: [WebSiteComponent]
})
export class WebSiteModule { }
