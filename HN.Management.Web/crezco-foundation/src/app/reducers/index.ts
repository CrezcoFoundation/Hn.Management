import { isDevMode } from '@angular/core';
import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { DonationInterface } from 'src/give/interfaces/donation.interface';
import { donationReducer } from 'src/give/reducers/donation.reducer';

export interface CrezcoState {
  donationReducer: DonationInterface
}

export const crezcoReducers: ActionReducerMap<CrezcoState> = {
  donationReducer
};


export const metaReducers: MetaReducer<CrezcoState>[] = isDevMode() ? [] : [];
