import { NgModule } from '@angular/core';
import { ProjectsComponent } from './projects/projects.component';
import { ProjectsRoutes } from './projects.routes';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: ProjectsComponent,
    children: ProjectsRoutes,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProjectsRoutingModule {}
