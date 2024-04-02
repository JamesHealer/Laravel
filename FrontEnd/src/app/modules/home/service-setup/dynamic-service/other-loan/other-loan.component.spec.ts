import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OtherLoanComponent } from './other-loan.component';

describe('OtherLoanComponent', () => {
  let component: OtherLoanComponent;
  let fixture: ComponentFixture<OtherLoanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OtherLoanComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OtherLoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
