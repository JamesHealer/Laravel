import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OtherLoanOfferComponent } from './other-loan-offer.component';

describe('OtherLoanOfferComponent', () => {
  let component: OtherLoanOfferComponent;
  let fixture: ComponentFixture<OtherLoanOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OtherLoanOfferComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OtherLoanOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
