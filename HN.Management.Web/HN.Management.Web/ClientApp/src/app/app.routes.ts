import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'contact-us',
    loadComponent: () => import('./website/contact-us/contact-us/contact-us.component').then(c => c.ContactUsComponent)
  },
  {
    path: 'crezco-story',
    loadComponent: () => import('./website/crezco-story/crezco-story/crezco-story.component').then(c => c.CrezcoStoryComponent)
  },
  {
    path: 'give',
    loadComponent: () => import('./website/give/give/give.component').then(c => c.GiveComponent)
  },
  { path: 'projects/university',
    loadComponent: () => import('./website/projects/university-sponsorship/university-sponsorship.component').then(c => c.UniversitySponsorshipComponent)
  },
  { path: 'projects/special-education',
    loadComponent: () => import('./website/projects/special-education/special-education.component').then(c => c.SpecialEducationComponent)
  },
  { path: 'projects/community-support',
    loadComponent: () => import('./website/projects/community-support/community-support.component').then(c => c.CommunitySupportComponent)
  },
  { path: 'projects/mission-trip',
    loadComponent: () => import('./website/projects/student-mission-trip/student-mission-trip.component').then(c => c.StudentMissionTripComponent)
  },
  { path: '',
    loadComponent: () => import('./website/home/home.component').then(c => c.HomeComponent)
  },
];
