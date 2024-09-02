import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';
import Swal from 'sweetalert2'
import { PrivilegeService } from '../../../../core/services/privilege.service';
import { Privilege } from '../../../../core/interfaces/privilege';
import { RolePrivilegeService } from '../../../../core/services/role-privilege.service';
import { RolePrivilege, RolePrivilegeRequest } from '../../../../core/interfaces/role-privilege';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-assign-privilege',
  templateUrl: './assign-privilege.component.html'
})
export class AssignPrivilegeComponent implements OnInit {

  assignPrivilegeForm =  new FormGroup({
    privilageId: new FormControl,
  });

  loading = false;
  privileges?: Privilege[];
  rolePrivilege?: RolePrivilege[];
  rolePrivilegeRequest: RolePrivilegeRequest = {
    roleId: '',
    privilagesIds: []
  };
  roleId?: string;
  selectedPrivileges: any[] = [];
  
  constructor( private formBuilder: FormBuilder, private privilegeService: PrivilegeService, private rolePrivilegeService: RolePrivilegeService, private router: Router, private route: ActivatedRoute ) {
  }

  ngOnInit() {  
    this.roleId = this.route.snapshot.params['id'];  

    this.assignPrivilegeForm = this.formBuilder.group({
      privilageId: [''],
    });

    this.privilegeService.getAll().pipe(first()).subscribe( privileges => {
      this.privileges = privileges;
    })
    this.rolePrivilegeRequest.roleId = this.roleId!;

  }

  get f(){
    return this.assignPrivilegeForm!.controls;
  }

  assignPrivilege(){
    this.rolePrivilegeService.create(this.rolePrivilegeRequest).pipe(first())
    .subscribe({
        next: () => {
            //this.router.navigate(['/users'], { relativeTo: this.route });
        }
    });
  }

  get selectedPrivilagesId() {
    return this.privileges?.filter((e, i) => this.selectedPrivileges[i]);
  }

  onSubmited(){

  }
}
