import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Role } from '../../../core/interfaces/role';
import { ActivatedRoute, Router } from '@angular/router';
import { RoleService } from '../../../core/services/role.service';
import { first } from 'rxjs';

@Component({
  selector: 'app-new-role',
  templateUrl: './new-role.component.html'
})
export class NewRoleComponent implements OnInit {

  newRoleForm =  new FormGroup({
    roleName: new FormControl
  });

  role:Role= {
    id: '',
    name: '',
    isDeleted: false,
  };

  fieldTextType: boolean = false;
  loading = false;
  submitted = false;
  error: any;

  constructor(
    private formBuilder: FormBuilder, 
    private roleService: RoleService,
    private router: Router, 
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.newRoleForm = this.formBuilder.group({
      roleName: ['', Validators.required],
    });
  }

  get f(){
    return this.newRoleForm!.controls;
  }

  toggleFieldTextType(): void {
    this.fieldTextType = !this.fieldTextType;
  }

  onSubmited() {

    this.submitted = true;

    // stop here if form is invalid
    if (this.newRoleForm.invalid) {
      return;
    }

    this.loading = true;

    this.role.name = this.f['roleName'].value;

    this.roleService.create(this.role)
        .pipe(first())
        .subscribe({
            next: () => {
                this.router.navigate(['/assign-pivileges'], { relativeTo: this.route });
            }
        });
  }

}
