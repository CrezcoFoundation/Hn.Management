import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentMissionTripComponent } from './student-mission-trip.component';

describe('StudentMissionTripComponent', () => {
  let component: StudentMissionTripComponent;
  let fixture: ComponentFixture<StudentMissionTripComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StudentMissionTripComponent],
    });
    fixture = TestBed.createComponent(StudentMissionTripComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
