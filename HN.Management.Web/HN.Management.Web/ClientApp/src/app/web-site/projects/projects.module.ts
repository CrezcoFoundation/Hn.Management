import { CommonModule, NgOptimizedImage } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { I18NextModule, ITranslationService, I18NEXT_SERVICE, I18NextTitle, defaultInterpolationFormat } from 'angular-i18next';
import { NgModule, APP_INITIALIZER, LOCALE_ID  } from '@angular/core';
import { RouterModule } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';

import { CommunitySupportComponent } from './community-support/community-support.component';
import { MedicalAssistanceComponent } from './medical-assistance/medical-assistance.component';
import { ProjectsComponent } from './projects/projects.component';
import { ProjectsRoutingModule } from './projects-routing.module';
import { SharedModule } from '../shared/shared.module';
import { SpecialEducationComponent } from './special-education/special-education.component';
import { StudentMissionTripComponent } from './student-mission-trip/student-mission-trip.component';
import { UniversitySponsorshipComponent } from './university-sponsorship/university-sponsorship.component';


export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/locales/', '.translation.json');
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
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: HttpLoaderFactory,
          deps: [HttpClient]
      }
  }),
    RouterModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule,
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
  providers: [],
})
export class ProjectsModule {}
