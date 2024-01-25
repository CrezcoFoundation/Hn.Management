import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

// Custom imports from Projects Folder
import { UniversitySponsorshipComponent } from './university-sponsorship/university-sponsorship.component';
import { StudentMissionTripComponent } from './student-mission-trip/student-mission-trip.component';
import { SpecialEducationComponent } from './special-education/special-education.component';
import { MedicalAssistanceComponent } from './medical-assistance/medical-assistance.component';
import { CommunitySupportComponent } from './community-support/community-support.component';
import { ProjectsRoutingModule } from './projects-routing.module';
import { ProjectsComponent } from './projects/projects.component';

import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

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
    ProjectsRoutingModule,
  ],
  bootstrap: [
    UniversitySponsorshipComponent,
    StudentMissionTripComponent,
    SpecialEducationComponent,
    MedicalAssistanceComponent,
    CommunitySupportComponent,
  ],
  exports: [
    UniversitySponsorshipComponent,
    StudentMissionTripComponent,
    SpecialEducationComponent,
    MedicalAssistanceComponent,
    CommunitySupportComponent,
  ],
})
export class ProjectsModule {}
