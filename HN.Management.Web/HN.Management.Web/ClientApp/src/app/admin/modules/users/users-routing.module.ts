import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UsersComponent } from './users.component';
import { PrivilegeComponent } from '../privilege/privilege.component';
import { RoleComponent } from '../role/role.component';
import { AddUserComponent } from './add-user/add-user.component';

const routes: Routes = [
  { path: '', component: UsersComponent },
  { path: 'roles', component: RoleComponent},
  { path: 'new-user', component: AddUserComponent},
  { path: 'privileges', component: PrivilegeComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
