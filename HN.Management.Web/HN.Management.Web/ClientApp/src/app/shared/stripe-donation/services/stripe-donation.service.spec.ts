import { TestBed } from '@angular/core/testing';

import { StripeDonationService } from './stripe-donation.service';

describe('StripeDonationService', () => {
  let service: StripeDonationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StripeDonationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
