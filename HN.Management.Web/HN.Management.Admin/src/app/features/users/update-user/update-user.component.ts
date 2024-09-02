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
  selector: 'app-update-user',
  templateUrl: './update-user.component.html'
})
export class UpdateUserComponent implements OnInit{
  
  updateUserForm =  new FormGroup({
    email: new FormControl,
    userName: new FormControl,
    roleId: new FormControl,
    roleName: new FormControl
  });

  role:Role= {
    id: '',
    name: '',
    isDeleted: false,
  };

  fieldTextType: boolean = false;
  roles?: Role[];
  loading = false;
  submitted = false;
  error: any;
  id?: string;

  user: User = {
    isDeleted: false,
    email: '',
    username: '',
    isEmailConfirmed: false,
    password: '',
    role: this.role,
    id: ''
  }

  constructor(
    private formBuilder: FormBuilder, 
    private userService: UserService, 
    private roleService: RoleService,
    private router: Router, 
    private route: ActivatedRoute
    ) {}
  
    ngOnInit(): void {
      this.id = this.route.snapshot.params['id'];

      this.updateUserForm = this.formBuilder.group({
        email: ['', [Validators.required, Validators.email]],
        userName: ['', Validators.required],
        roleId: ['', Validators.required],
        roleName: ['']
      });
  
      this.getRoles();
      this.getUser(this.id!);
    }

    get f(){
      return this.updateUserForm!.controls;
    }
  
    toggleFieldTextType(): void {
      this.fieldTextType = !this.fieldTextType;
    }
  
    getRoles() {
      this.roleService.getAll().pipe(first()).subscribe( roles => {
        this.roles = roles;
      });
    }

    getUser(id: string){
      this.userService.getById(id).pipe(first()).subscribe( user => {
        this.updateUserForm.setValue({
          email: user.email,
          userName: user.username,
          roleId: user.role?.id,
          roleName: user.role?.name
        })
        });
      }
  
    updateRoleSelector(event: any): void {
      let roleName = event.target.options[event.target.options.selectedIndex].text;
      this.updateUserForm.controls.roleName.setValue(roleName);
    }

    updateUser(){
      // assign values from registerForm to user
      this.user.id = this.id!;
      this.user.email = this.f['email'].value;
      this.user.username = this.f['userName'].value;
      this.user.password = 'donordonor';
      this.user.role!.id = this.f['roleId'].value;
      this.user.role!.name = this.f['roleName'].value;
  
      this.userService.update(this.user)
          .pipe(first())
          .subscribe({
              next: () => {
                  this.router.navigate(['/users'], { relativeTo: this.route });
              }
          });
    }
  
    onSubmited() {
  
      this.submitted = true;
  
      // stop here if form is invalid
      if (this.updateUserForm.invalid) {
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
            text: "The user has been updated.",
            icon: "success"
          });
          this.updateUser();
        } else if (
          /* Read more about handling dismissals below */
          result.dismiss === Swal.DismissReason.cancel
        ) {
          swalWithBootstrapButtons.fire({
            title: "Cancelled",
            text: "The user hasn't been updated",
            icon: "error"
          });
          this.router.navigate(['/users'], { relativeTo: this.route });
        }
      });

    }

}
