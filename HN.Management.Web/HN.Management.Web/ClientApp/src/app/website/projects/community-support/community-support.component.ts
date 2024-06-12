import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { SharedBannerComponent } from "../../../shared/shared-banner/shared-banner.component";
import { ContactUsComponent } from '../../contact-us/contact-us/contact-us.component';

@Component({
    standalone: true,
    selector: 'app-community-support',
    templateUrl: './community-support.component.html',
    styleUrls: ['./community-support.component.scss'],
    imports: [
      CommonModule,
      TranslateModule,
      ContactUsComponent,
      RouterModule,
      SharedBannerComponent]
})
export class CommunitySupportComponent {}
