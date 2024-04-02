import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntertainmentTicketsOfferComponent } from './entertainment-tickets-offer.component';

describe('EntertainmentTicketsOfferComponent', () => {
  let component: EntertainmentTicketsOfferComponent;
  let fixture: ComponentFixture<EntertainmentTicketsOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EntertainmentTicketsOfferComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EntertainmentTicketsOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
