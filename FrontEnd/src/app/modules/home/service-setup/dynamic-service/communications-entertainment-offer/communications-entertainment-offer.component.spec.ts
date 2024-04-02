import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommunicationsEntertainmentOfferComponent } from './communications-entertainment-offer.component';

describe('CommunicationsEntertainmentOfferComponent', () => {
  let component: CommunicationsEntertainmentOfferComponent;
  let fixture: ComponentFixture<CommunicationsEntertainmentOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommunicationsEntertainmentOfferComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CommunicationsEntertainmentOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
