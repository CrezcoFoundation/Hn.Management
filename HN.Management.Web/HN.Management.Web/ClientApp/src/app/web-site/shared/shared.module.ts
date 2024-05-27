import { CommonModule, NgOptimizedImage } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { I18NextModule, ITranslationService, I18NEXT_SERVICE, I18NextTitle, defaultInterpolationFormat } from 'angular-i18next';
import { NgModule, APP_INITIALIZER, LOCALE_ID  } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';

// shared components
import { FooterComponent } from './footer/footer.component';
import { MultipleItemsSliderComponent } from './multiple-items-slider/multiple-items-slider.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { PaypalComponent } from './donation-options/paypal/paypal.component';
import { SharedBannerComponent } from './shared-banner/shared-banner.component';

// Translate imports
import Backend from 'i18next-chained-backend';
import LanguageDetector from 'i18next-browser-languagedetector';

// translation files
import en from '../../../assets/locales/en.translation.json';
import es from '../../../assets/locales/es.translation.json';

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
  provide: Title,
  useClass: I18NextTitle
},
{
  provide: LOCALE_ID,
  deps: [I18NEXT_SERVICE],
  useFactory: localeIdFactory
}];

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/locales/', '.translation.json');
}

@NgModule({
  declarations: [
    NavBarComponent,
    MultipleItemsSliderComponent,
    FooterComponent,
    PaypalComponent,
    SharedBannerComponent,
  ],
  imports: [
    NgOptimizedImage,
    RouterModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    I18NextModule.forRoot()],
  exports: [
    PaypalComponent,
    MultipleItemsSliderComponent,
    FooterComponent,
    NavBarComponent,
    SharedBannerComponent
  ],
  providers: [I18N_PROVIDERS],
  bootstrap: [NavBarComponent]
})
export class SharedModule {}
