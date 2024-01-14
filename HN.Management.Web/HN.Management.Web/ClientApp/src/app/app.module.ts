import { NgModule, isDevMode,  APP_INITIALIZER, LOCALE_ID } from '@angular/core';
import { I18NextModule, ITranslationService, I18NEXT_SERVICE, I18NextTitle, defaultInterpolationFormat } from 'angular-i18next';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';

// custom
import { SharedModule } from 'src/app/web-site/shared/shared.module';
import { HomeModule } from 'src/app/web-site/home/home.module';
import { GiveModule } from 'src/app/web-site/give/give.module';
import { CrezcoStoryModule } from 'src/app/web-site/crezco-story/crezco-story.module';
import { ContactUsModule } from 'src/app/web-site/contact-us/contact-us.module';
import { StoreModule } from '@ngrx/store';
import { crezcoReducers, metaReducers } from './reducers';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { WebSiteModule } from './web-site/web-site.module';

// i18n Translate
import Backend from 'i18next-chained-backend';
import LanguageDetector from 'i18next-browser-languagedetector';

// Translation files
import en from '../assets/locales/en.translation.json';
import es from '../assets/locales/es.translation.json';

const resources = {
  en: {
    translation: en
  },
  es: {
    translation: es
  }
};

export function appInit(i18next: ITranslationService) {
  return () =>
      i18next
      .use(Backend)
      .use(LanguageDetector)
      .init({
      resources,
      supportedLngs: ['en', 'es'],
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
  /* provide: Title, */
  useClass: I18NextTitle
},
{
  provide: LOCALE_ID,
  deps: [I18NEXT_SERVICE],
  useFactory: localeIdFactory
}];

@NgModule({
  declarations: [AppComponent],
  providers: [I18N_PROVIDERS],
  bootstrap: [AppComponent],
  imports: [
    WebSiteModule,
    ContactUsModule,
    CrezcoStoryModule,
    GiveModule,
    HomeModule,
    SharedModule,
    BrowserModule,
    AppRoutingModule,
    StoreModule.forRoot(crezcoReducers, {
      metaReducers,
    }),
    StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
    ReactiveFormsModule,
    I18NextModule.forRoot()
  ],
})
export class AppModule {}
