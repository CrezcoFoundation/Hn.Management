import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FullPageCarouselComponent } from './full-page-carousel.component';

describe('FullPageCarouselComponent', () => {
  let component: FullPageCarouselComponent;
  let fixture: ComponentFixture<FullPageCarouselComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FullPageCarouselComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(FullPageCarouselComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
