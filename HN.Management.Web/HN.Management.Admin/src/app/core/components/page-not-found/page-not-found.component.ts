import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.component.html'
})
export class PageNotFoundComponent {
  
  constructor( private router: Router ) {
  }
back() {
  if( localStorage.getItem('currentUser') ){
    this.router.navigate(['/dashboard']);
  }else{
    this.router.navigate(['/login']);
  }
  
}

}
