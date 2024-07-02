import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Role } from '../../interfaces/role';
import { RoleService } from '../../services/role.service';
import { first } from 'rxjs';

@Component({
  selector: 'app-role',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss']
})
export class RoleComponent {

  loading = false;
  roles?: Role[];
  timeLeft: number = 5;
  interval: any;

  constructor( private roleService: RoleService) {}

  ngOnInit() {
    this.loading = true;
    this.startTimer();
    this.roleService.getAll().pipe(first()).subscribe( roles => {
      this.loading = false;
      this.roles = roles;
    });
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
