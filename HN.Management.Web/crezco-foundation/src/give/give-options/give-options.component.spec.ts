import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GiveOptionsComponent } from './give-options.component';

describe('GiveOptionsComponent', () => {
  let component: GiveOptionsComponent;
  let fixture: ComponentFixture<GiveOptionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GiveOptionsComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(GiveOptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
