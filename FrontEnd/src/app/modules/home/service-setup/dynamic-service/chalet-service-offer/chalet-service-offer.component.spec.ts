import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChaletServiceOfferComponent } from './chalet-service-offer.component';

describe('ChaletServiceOfferComponent', () => {
  let component: ChaletServiceOfferComponent;
  let fixture: ComponentFixture<ChaletServiceOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChaletServiceOfferComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChaletServiceOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
