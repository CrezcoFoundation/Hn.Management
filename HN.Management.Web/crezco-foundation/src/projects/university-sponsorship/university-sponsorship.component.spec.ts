import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UniversitySponsorshipComponent } from './university-sponsorship.component';

describe('UniversitySponsorshipComponent', () => {
  let component: UniversitySponsorshipComponent;
  let fixture: ComponentFixture<UniversitySponsorshipComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UniversitySponsorshipComponent]
    });
    fixture = TestBed.createComponent(UniversitySponsorshipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
