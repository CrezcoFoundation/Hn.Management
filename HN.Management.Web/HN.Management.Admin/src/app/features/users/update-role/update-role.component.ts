import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Role } from '../../../core/interfaces/role';
import { User } from '../../../core/interfaces/user';
import { RoleService } from '../../../core/services/role.service';
import { UserService } from '../../../core/services/user.service';
import { first } from 'rxjs';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-update-role',
  templateUrl: './update-role.component.html'
})
export class UpdateRoleComponent implements OnInit{

  updateRoleForm =  new FormGroup({
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
  id?: string;

  constructor(
    private formBuilder: FormBuilder, 
    private roleService: RoleService,
    private router: Router, 
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    this.updateRoleForm = this.formBuilder.group({
      roleName: ['', Validators.required]
    });
    this.getRole(this.id!);
  }

  get f(){
    return this.updateRoleForm!.controls;
  }

  toggleFieldTextType(): void {
    this.fieldTextType = !this.fieldTextType;
  }

  getRole(id: string){
    this.roleService.getById(id).pipe(first()).subscribe( role => {
      this.updateRoleForm.setValue({
        roleName: role.name
      })
      });
    }

  updateRole(){
    // assign values from registerForm to user
    this.role.id = this.id!;
    this.role.name = this.f['roleName'].value;

    this.roleService.update(this.role)
        .pipe(first())
        .subscribe({
            next: () => {
                this.router.navigate(['/roles'], { relativeTo: this.route });
            }
        });
  }

  onSubmited() {

    this.submitted = true;

    // stop here if form is invalid
    if (this.updateRoleForm.invalid) {
      return;
    }

    this.loading = true;

    const swalWithBootstrapButtons = Swal.mixin({
      customClass: {
        confirmButton: "btn btn-success",
        cancelButton: "btn btn-danger"
      },
      buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
      title: "Are you sure?",
      text: "You won't be able to revert this!",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "Yes, update it!",
      cancelButtonText: "No, cancel!",
      reverseButtons: true
    }).then((result) => {
      if (result.isConfirmed) {
        swalWithBootstrapButtons.fire({
          title: "Updated!",
          text: "The role has been updated.",
          icon: "success"
        });
        this.updateRole();
      } else if (
        /* Read more about handling dismissals below */
        result.dismiss === Swal.DismissReason.cancel
      ) {
        swalWithBootstrapButtons.fire({
          title: "Cancelled",
          text: "The role hasn't been updated",
          icon: "error"
        });
        this.router.navigate(['/roles'], { relativeTo: this.route });
      }
    });

  }
}
