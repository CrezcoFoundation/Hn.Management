import { Component } from '@angular/core';

@Component({
  standalone: false,
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})
export class NavBarComponent {
  constructor() {}

  toggleShow: string = '';
  toggleShowList: string = '';

  toggleDropdown: boolean = false;

  mouseEnter(ul: string) {
    this.toggleShow = 'show';
    this.toggleShowList = 'show';
  }
  mouseLeave(ul: string) {
    this.toggleShow = '';
  }

  /* Menu icon transition */
  isMenuOpen = false;

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
