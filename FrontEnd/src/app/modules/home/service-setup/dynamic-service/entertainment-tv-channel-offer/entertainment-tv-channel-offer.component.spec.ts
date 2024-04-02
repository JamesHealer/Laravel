import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EntertainmentTvChannelOfferComponent } from './entertainment-tv-channel-offer.component';

describe('EntertainmentTvChannelOfferComponent', () => {
  let component: EntertainmentTvChannelOfferComponent;
  let fixture: ComponentFixture<EntertainmentTvChannelOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EntertainmentTvChannelOfferComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EntertainmentTvChannelOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
