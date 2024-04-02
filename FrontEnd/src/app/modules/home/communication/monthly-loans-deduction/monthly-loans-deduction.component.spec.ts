import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthlyLoansDeductionComponent } from './monthly-loans-deduction.component';

describe('MonthlyLoansDeductionComponent', () => {
  let component: MonthlyLoansDeductionComponent;
  let fixture: ComponentFixture<MonthlyLoansDeductionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MonthlyLoansDeductionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MonthlyLoansDeductionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
