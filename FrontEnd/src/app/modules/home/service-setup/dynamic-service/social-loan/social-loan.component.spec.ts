import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SocialLoanComponent } from './social-loan.component';

describe('SocialLoanComponent', () => {
  let component: SocialLoanComponent;
  let fixture: ComponentFixture<SocialLoanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SocialLoanComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SocialLoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
