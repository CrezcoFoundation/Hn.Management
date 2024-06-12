import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { AppComponent } from 'src/app/app.component';

@Component({
  standalone: true,
  imports: [
    RouterModule,
    CommonModule,
    HttpClientModule,
    TranslateModule,
    AppComponent
  ],
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss'],
})
export class FooterComponent {

  dateYear = new Date();
  crezcoYear = this.dateYear.getFullYear();

}
