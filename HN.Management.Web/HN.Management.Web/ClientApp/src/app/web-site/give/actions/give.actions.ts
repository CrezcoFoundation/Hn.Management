import { createAction, props } from '@ngrx/store';
import { DonatationAreasInterface } from '../interfaces/donation.interface';

export const fillDonationAreas = createAction(
  '[give donation areas form] fillDonationAreas',
  props<{ donationAreas: DonatationAreasInterface }>()
);
export const donationareasSummary = createAction(
  '[give donation areas form] donationareasSummary'
);
export const reset = createAction('[give donation areas form] Reset');
