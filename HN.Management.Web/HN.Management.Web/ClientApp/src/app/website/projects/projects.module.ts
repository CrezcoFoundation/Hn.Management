import { CommonModule, NgOptimizedImage } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
// Custom imports
import { CommunitySupportComponent } from './community-support/community-support.component';
import { ProjectsComponent } from './projects/projects.component';
import { ProjectsRoutingModule } from './projects-routing.module';
import { SharedModule } from '../../shared/shared.module';
import { SpecialEducationComponent } from './special-education/special-education.component';
import { StudentMissionTripComponent } from './student-mission-trip/student-mission-trip.component';
import { UniversitySponsorshipComponent } from './university-sponsorship/university-sponsorship.component';
// Language imports
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/locales/', '.translation.json');
}

@NgModule({
  declarations: [
    UniversitySponsorshipComponent,
    StudentMissionTripComponent,
    SpecialEducationComponent,
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
    CommunitySupportComponent,
  ],
  bootstrap: [
    UniversitySponsorshipComponent,
    StudentMissionTripComponent,
    SpecialEducationComponent,
    CommunitySupportComponent,
  ],
  providers: [],
})
export class ProjectsModule {}
