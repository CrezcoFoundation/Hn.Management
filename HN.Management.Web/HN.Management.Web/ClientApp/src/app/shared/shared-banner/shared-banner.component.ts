import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from '../shared.module';

@Component({
  standalone: true,
  imports: [
    RouterModule,
    CommonModule,
    HttpClientModule,
    TranslateModule,
    SharedModule
  ],
  selector: 'shared-banner',
  templateUrl: './shared-banner.component.html',
  styleUrls: ['./shared-banner.component.scss']
})
export class SharedBannerComponent {

}
