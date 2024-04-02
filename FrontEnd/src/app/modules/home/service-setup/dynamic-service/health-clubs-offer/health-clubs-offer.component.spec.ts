import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthClubsOfferComponent } from './health-clubs-offer.component';

describe('HealthClubsOfferComponent', () => {
  let component: HealthClubsOfferComponent;
  let fixture: ComponentFixture<HealthClubsOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HealthClubsOfferComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HealthClubsOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
