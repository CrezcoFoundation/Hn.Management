import { APP_INITIALIZER, LOCALE_ID, NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { Title } from '@angular/platform-browser';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { ITranslationService, I18NextModule, defaultInterpolationFormat, I18NEXT_SERVICE, I18NextTitle } from 'angular-i18next';
import { CommunitySupportComponent } from './community-support/community-support.component';
import { MedicalAssistanceComponent } from './medical-assistance/medical-assistance.component';
import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects/projects.component';
import { SpecialEducationComponent } from './special-education/special-education.component';
import { StudentMissionTripComponent } from './student-mission-trip/student-mission-trip.component';
import { UniversitySponsorshipComponent } from './university-sponsorship/university-sponsorship.component';


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
  return new TranslateHttpLoader(http, '../../../assets/locales/', '.translation.json');
}

@NgModule({
  declarations: [
    UniversitySponsorshipComponent,
    StudentMissionTripComponent,
    SpecialEducationComponent,
    MedicalAssistanceComponent,
    CommunitySupportComponent,
    ProjectsComponent,
  ],
  imports: [
    NgOptimizedImage,
    HttpClientModule,
    TranslateModule.forChild({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    }),
    /* I18NextModule.forRoot(), */
    RouterModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    ProjectsRoutingModule,
  ],
  exports: [
    UniversitySponsorshipComponent,
    StudentMissionTripComponent,
    SpecialEducationComponent,
    MedicalAssistanceComponent,
    CommunitySupportComponent,
  ],
  bootstrap: [
    UniversitySponsorshipComponent,
    StudentMissionTripComponent,
    SpecialEducationComponent,
    MedicalAssistanceComponent,
    CommunitySupportComponent,
  ],
  providers: [I18N_PROVIDERS],
})
export class ProjectsModule {}
