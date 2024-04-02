import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WifiInternetOfferComponent } from './wifi-internet-offer.component';

describe('WifiInternetOfferComponent', () => {
  let component: WifiInternetOfferComponent;
  let fixture: ComponentFixture<WifiInternetOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WifiInternetOfferComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WifiInternetOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
