import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StripeDonationComponent } from './stripe-donation.component';

describe('StripeDonationComponent', () => {
  let component: StripeDonationComponent;
  let fixture: ComponentFixture<StripeDonationComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [StripeDonationComponent]
    });
    fixture = TestBed.createComponent(StripeDonationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
