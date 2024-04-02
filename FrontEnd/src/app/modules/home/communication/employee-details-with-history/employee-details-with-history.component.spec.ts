import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeDetailsWithHistoryComponent } from './employee-details-with-history.component';

describe('EmployeeDetailsWithHistoryComponent', () => {
  let component: EmployeeDetailsWithHistoryComponent;
  let fixture: ComponentFixture<EmployeeDetailsWithHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeDetailsWithHistoryComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeeDetailsWithHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
