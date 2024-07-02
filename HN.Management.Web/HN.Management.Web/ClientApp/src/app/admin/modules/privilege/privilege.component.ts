import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Privilege } from '../../interfaces/privilege';
import { PrivilegeService } from '../../services/privilege.service';
import { first } from 'rxjs';

@Component({
  selector: 'app-privilege',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './privilege.component.html',
  styleUrls: ['./privilege.component.scss']
})
export class PrivilegeComponent {
  
  loading = false;
  privileges?: Privilege[];
  timeLeft: number = 5;
  interval: any;

  constructor( private privilegeService: PrivilegeService ) {}

  ngOnInit() {
    this.loading = true;
    this.startTimer();
    this.privilegeService.getAll().pipe(first()).subscribe( privileges => {
      this.loading = false;
      this.privileges = privileges;
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
