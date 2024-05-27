import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SharedBannerComponent } from './shared-banner.component';

describe('SharedBannerComponent', () => {
  let component: SharedBannerComponent;
  let fixture: ComponentFixture<SharedBannerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SharedBannerComponent]
    });
    fixture = TestBed.createComponent(SharedBannerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
