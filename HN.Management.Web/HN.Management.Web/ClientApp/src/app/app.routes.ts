import { Routes } from '@angular/router';
import { HomeComponent } from 'src/app/website/home/home.component';

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

  // Childs Module imports
  {
    path: 'auth',
    loadChildren: () => import('../app/core/auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: 'projects',
    loadChildren: () =>
      import('../app/website/projects/projects.module').then((m) => m.ProjectsModule),
  },
  { path: '',
    loadComponent: () => import('./website/home/home.component').then(c => c.HomeComponent)
  },
];
