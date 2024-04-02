import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OmraLoanOfferComponent } from './omra-loan-offer.component';

describe('OmraLoanOfferComponent', () => {
  let component: OmraLoanOfferComponent;
  let fixture: ComponentFixture<OmraLoanOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OmraLoanOfferComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OmraLoanOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
