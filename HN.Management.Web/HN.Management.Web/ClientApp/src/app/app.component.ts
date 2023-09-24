import { Component, OnInit } from '@angular/core';
import Aos from 'aos';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'crezco-foundation';

  ngOnInit() {
    Aos.init({
      once: false,
      duration: 800,
      easing: 'ease',
    });
  }
}
