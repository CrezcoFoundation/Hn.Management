import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MultipleItemsSliderComponent } from './multiple-items-slider.component';

describe('MultipleItemsSliderComponent', () => {
  let component: MultipleItemsSliderComponent;
  let fixture: ComponentFixture<MultipleItemsSliderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MultipleItemsSliderComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(MultipleItemsSliderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
