import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

// Custom imports from Projects Folder
import { UniversitySponsorshipComponent } from './university-sponsorship/university-sponsorship.component';
import { StudentMissionTripComponent } from './student-mission-trip/student-mission-trip.component';
import { SpecialEducationComponent } from './special-education/special-education.component';
import { MedicalAssistanceComponent } from './medical-assistance/medical-assistance.component';
import { CommunitySupportComponent } from './community-support/community-support.component';
import { ProjectsRoutingModule } from './projects-routing.module';

@NgModule({
  declarations: [
    UniversitySponsorshipComponent,
    StudentMissionTripComponent,
    SpecialEducationComponent,
    MedicalAssistanceComponent,
    CommunitySupportComponent,
  ],
  imports: [CommonModule, BrowserModule, RouterModule, ProjectsRoutingModule],
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
