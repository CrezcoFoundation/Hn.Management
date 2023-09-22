import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import Aos from 'aos';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  constructor(private router: Router) {}

  title = 'crezco-foundation';

  ngOnInit() {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        // Cuando se completa una navegación, lleva la página al principio.
        window.scrollTo(0, 0);
      }
    });

    Aos.init({
      once: false,
      duration: 800,
      easing: 'ease',
    });
  }
}
