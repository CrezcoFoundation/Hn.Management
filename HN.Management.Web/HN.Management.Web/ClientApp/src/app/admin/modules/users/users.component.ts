import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from '../../services/user.service';
import { User } from '../../interfaces/user';
import { first } from 'rxjs';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent {
  
  loading = false;
  users?: User[];
  timeLeft: number = 5;
  interval: any;

  constructor( private userService: UserService ) {
  }

  ngOnInit() {
    this.loading = true;
    this.startTimer();
    this.userService.getAll().pipe(first()).subscribe( users => {
      this.loading = false;
      this.users = users;
    })
  }

  startTimer() {
    this.interval = setInterval(() => {
      if(this.timeLeft > 0){
        this.timeLeft--;
        this.loading = true;
      } else {
        this.loading = false;
      }
    }, 1000)
  }
}
