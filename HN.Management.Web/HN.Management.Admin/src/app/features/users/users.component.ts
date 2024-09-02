import { Component, OnInit } from '@angular/core';
import { User } from '../../core/interfaces/user';
import { UserService } from '../../core/services/user.service';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})
export class UsersComponent implements OnInit {

  loading = false;
  users?: User[];
  interval: any;
  
  constructor( private userService: UserService, private router: Router ) {
  }

  ngOnInit() {    
    this.userService.getAll().pipe(first()).subscribe( users => {
      this.users = users;
    })
  }

  newUser(){
    this.router.navigate(['/users/add-user']);
  }

  edit(id: string){
    this.router.navigate([`/edit-user/${id}`]);
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
        this.userService.delete(id)
        .pipe(first())
        .subscribe(() => this.users = this.users!.filter(x => x.id !== id));
        swalWithBootstrapButtons.fire({
          title: "Deleted!",
          text: "The user has been deleted.",
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
