import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from "../../../shared/shared.module";
import { RouterModule } from '@angular/router';
import { SharedBannerComponent } from "../../../shared/shared-banner/shared-banner.component";

@Component({
    standalone: true,
    selector: 'app-university-sponsorship',
    templateUrl: './university-sponsorship.component.html',
    styleUrls: ['./university-sponsorship.component.scss'],
    imports: [CommonModule, TranslateModule, SharedModule, RouterModule, SharedBannerComponent]
})
export class UniversitySponsorshipComponent {
}
