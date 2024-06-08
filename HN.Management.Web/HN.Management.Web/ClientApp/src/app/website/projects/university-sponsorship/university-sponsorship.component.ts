import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { RouterModule } from '@angular/router';
import { SharedBannerComponent } from "../../../shared/shared-banner/shared-banner.component";
import { ContactUsComponent } from '../../contact-us/contact-us/contact-us.component';

@Component({
    standalone: true,
    selector: 'app-university-sponsorship',
    templateUrl: './university-sponsorship.component.html',
    styleUrls: ['./university-sponsorship.component.scss'],
    imports: [
      CommonModule,
      TranslateModule,
      RouterModule,
      ContactUsComponent,
      SharedBannerComponent]
})
export class UniversitySponsorshipComponent {
}
