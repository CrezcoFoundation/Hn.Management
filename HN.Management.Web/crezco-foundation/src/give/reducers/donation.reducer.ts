import { createReducer, on } from '@ngrx/store';
import { fillDonationAreas, donationareasSummary, reset } from '../actions/give.actions';
import { DonationInterface } from '../interfaces/donation.interface';
import initialData from './initialData.json';

export const donationState: DonationInterface = {
    donationAreas: initialData.donationAreas
}

export const donationReducer = createReducer(
  donationState,
  on(fillDonationAreas, (state, donationAreas) => ({
    ...state,
    donationAreas: {...donationAreas.donationAreas}
  })),
  );