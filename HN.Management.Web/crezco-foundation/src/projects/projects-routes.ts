import { Routes } from '@angular/router';
import { UniversitySponsorshipComponent } from './university-sponsorship/university-sponsorship.component';
import { StudentMissionTripComponent } from './student-mission-trip/student-mission-trip.component';
import { SpecialEducationComponent } from './special-education/special-education.component';
import { MedicalAssistanceComponent } from './medical-assistance/medical-assistance.component';
import { CommunitySupportComponent } from './community-support/community-support.component';

export const ProjectsRoutes: Routes = [
  { path: 'university', component: UniversitySponsorshipComponent },
  { path: 'mission-trip', component: StudentMissionTripComponent },
  { path: 'special-education', component: SpecialEducationComponent },
  { path: 'medical-assistance', component: MedicalAssistanceComponent },
  { path: 'community-support', component: CommunitySupportComponent },
  {
    path: '**',
    redirectTo: 'university'
  }
];