import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MembershipWithdrawalComponent } from './membership-withdrawal.component';

describe('MembershipWithdrawalComponent', () => {
  let component: MembershipWithdrawalComponent;
  let fixture: ComponentFixture<MembershipWithdrawalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MembershipWithdrawalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MembershipWithdrawalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
