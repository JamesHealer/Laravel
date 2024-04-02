import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewemployeeinformationComponent } from './viewemployeeinformation.component';

describe('ViewemployeeinformationComponent', () => {
  let component: ViewemployeeinformationComponent;
  let fixture: ComponentFixture<ViewemployeeinformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewemployeeinformationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewemployeeinformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
