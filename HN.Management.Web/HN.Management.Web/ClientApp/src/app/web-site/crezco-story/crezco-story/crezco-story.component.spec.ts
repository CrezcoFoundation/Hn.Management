import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrezcoStoryComponent } from './crezco-story.component';

describe('CrezcoStoryComponent', () => {
  let component: CrezcoStoryComponent;
  let fixture: ComponentFixture<CrezcoStoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrezcoStoryComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(CrezcoStoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
