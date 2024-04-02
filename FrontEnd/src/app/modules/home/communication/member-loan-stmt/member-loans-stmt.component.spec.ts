import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberLoansStmtComponent } from './member-loans-stmt.component';

describe('MemberLoanStmtComponent', () => {
  let component: MemberLoansStmtComponent;
  let fixture: ComponentFixture<MemberLoansStmtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MemberLoansStmtComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MemberLoansStmtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
