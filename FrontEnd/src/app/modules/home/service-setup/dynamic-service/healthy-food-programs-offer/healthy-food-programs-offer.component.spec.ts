import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthyFoodProgramsOfferComponent } from './healthy-food-programs-offer.component';

describe('HealthyFoodProgramsOfferComponent', () => {
  let component: HealthyFoodProgramsOfferComponent;
  let fixture: ComponentFixture<HealthyFoodProgramsOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HealthyFoodProgramsOfferComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HealthyFoodProgramsOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
