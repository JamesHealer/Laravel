import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReRegisterFormerMemberComponent } from './re-register-former-member.component';

describe('ReRegisterFormerMemberComponent', () => {
  let component: ReRegisterFormerMemberComponent;
  let fixture: ComponentFixture<ReRegisterFormerMemberComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReRegisterFormerMemberComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReRegisterFormerMemberComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
