import { isDevMode } from '@angular/core';
import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer,
} from '@ngrx/store';
import { DonationInterface } from 'src/app/web-site/give/interfaces/donation.interface';
import { donationReducer } from 'src/app/web-site/give/reducers/donation.reducer';

export interface CrezcoState {
  donationReducer: DonationInterface;
}

export const crezcoReducers: ActionReducerMap<CrezcoState> = {
  donationReducer,
};

export const metaReducers: MetaReducer<CrezcoState>[] = isDevMode() ? [] : [];
