import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { SharedBannerComponent } from "../../../shared/shared-banner/shared-banner.component";

@Component({
    standalone: true,
    selector: 'app-community-support',
    templateUrl: './community-support.component.html',
    styleUrls: ['./community-support.component.scss'],
    imports: [CommonModule, TranslateModule, RouterModule, SharedModule, SharedBannerComponent]
})
export class CommunitySupportComponent {}
