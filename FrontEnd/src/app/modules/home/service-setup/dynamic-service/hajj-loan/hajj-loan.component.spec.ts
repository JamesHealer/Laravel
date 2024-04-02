import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HajjLoanComponent } from './hajj-loan.component';

describe('HajjLoanComponent', () => {
  let component: HajjLoanComponent;
  let fixture: ComponentFixture<HajjLoanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HajjLoanComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HajjLoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
