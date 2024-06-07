import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'projects',
    loadComponent: () => import('./website/projects/projects/projects.component').then(c => c.ProjectsComponent)
  },
  {
    path: 'child-example',
    loadChildren: () => import('./website/projects/projects.module').then(m => m.ProjectsModule)
  }
];
