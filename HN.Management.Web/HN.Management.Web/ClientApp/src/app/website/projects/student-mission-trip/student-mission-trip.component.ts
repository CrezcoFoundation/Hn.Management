import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { SharedBannerComponent } from "../../../shared/shared-banner/shared-banner.component";

@Component({
    standalone: true,
    selector: 'app-student-mission-trip',
    templateUrl: './student-mission-trip.component.html',
    styleUrls: ['./student-mission-trip.component.scss'],
    imports: [
      CommonModule,
      TranslateModule,
      RouterModule,
      SharedBannerComponent]
})
export class StudentMissionTripComponent {}
