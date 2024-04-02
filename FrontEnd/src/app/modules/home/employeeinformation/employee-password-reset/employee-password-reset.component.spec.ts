import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeePasswordResetComponent } from './employee-password-reset.component';

describe('EmployeePasswordResetComponent', () => {
  let component: EmployeePasswordResetComponent;
  let fixture: ComponentFixture<EmployeePasswordResetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeePasswordResetComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EmployeePasswordResetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
