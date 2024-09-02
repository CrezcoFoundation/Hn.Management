import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FooterComponent } from "./core/layout/footer/footer.component";
import { FormsModule } from '@angular/forms';
import { NavBarComponent } from "./core/layout/nav-bar/nav-bar.component";
import { NavigationEnd, Router, RouterOutlet } from '@angular/router';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import Aos from 'aos';
import { HomeComponent } from './website/home/home.component';

@Component({
  standalone: true,
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  imports: [
    HomeComponent,
    CommonModule,
    RouterOutlet,
    TranslateModule,
    FormsModule,
    FooterComponent,
    NavBarComponent]
})
export class AppComponent implements OnInit {

  isNavFooter!: boolean; 
  title = 'crezco-foundation';

  constructor(private router: Router) {
  }

  ngOnInit() { 
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        // Cuando se completa una navegación, lleva la página al principio.
        window.scrollTo(0, 0);
      }
    });

    Aos.init({
      once: false,
      duration: 500,
      easing: 'ease',
    });

    window.addEventListener('load', Aos.refresh);
  }
}
