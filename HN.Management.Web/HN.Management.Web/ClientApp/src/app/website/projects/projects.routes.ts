import { CommunitySupportComponent } from './community-support/community-support.component';
import { ProjectsComponent } from './projects/projects.component';
import { Routes } from '@angular/router';
import { SpecialEducationComponent } from './special-education/special-education.component';
import { StudentMissionTripComponent } from './student-mission-trip/student-mission-trip.component';
import { UniversitySponsorshipComponent } from './university-sponsorship/university-sponsorship.component';

export const ProjectsRoutes: Routes = [
  { path: 'university', component: UniversitySponsorshipComponent },
  { path: 'mission-trip', component: StudentMissionTripComponent },
  { path: 'special-education', component: SpecialEducationComponent },
  { path: 'community-support', component: CommunitySupportComponent },
];
