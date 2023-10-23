import { Component, OnInit } from '@angular/core';
import Aos from 'aos';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss'],
})
export class ProjectsComponent implements OnInit {
  ngOnInit() {
    Aos.init({
      once: false,
      duration: 800,
      easing: 'ease',
    });
  }
}
