import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import Swal from 'sweetalert2'
import { RoleService } from '../../../core/services/role.service';
import { Role } from '../../../core/interfaces/role';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html'
})
export class RolesComponent implements OnInit {
  loading = false;
  roles?: Role[];
  interval: any;
  
  constructor( private roleService: RoleService, private router: Router ) {
  }

  ngOnInit() {    
    this.roleService.getAll().pipe(first()).subscribe( roles => {
      this.roles = roles;
    })
  }

  newRole(){
    //this.router.navigate(['/admin/users/new-user']);
  }

  edit(id: string){
    this.router.navigate([`/edit-role/${id}`]);
  }

  assignPrivileges(id: string){
    this.router.navigate([`/assign-pivileges/${id}`]);
  }

  delete( id: string ){
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
      confirmButtonText: "Yes, delete it!",
      cancelButtonText: "No, cancel!",
      reverseButtons: true
    }).then((result) => {
      if (result.isConfirmed) {
        this.roleService.delete(id)
        .pipe(first())
        .subscribe(() => this.roles = this.roles!.filter(x => x.id !== id));
        swalWithBootstrapButtons.fire({
          title: "Deleted!",
          text: "The role has been deleted.",
          icon: "success"
        });
      } else if (
        /* Read more about handling dismissals below */
        result.dismiss === Swal.DismissReason.cancel
      ) {
        swalWithBootstrapButtons.fire({
          title: "Cancelled",
          text: "The user is safe :)",
          icon: "error"
        });
      }
    });
  }
}