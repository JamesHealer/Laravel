import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpringCampOfferComponent } from './spring-camp-offer.component';

describe('SpringCampOfferComponent', () => {
  let component: SpringCampOfferComponent;
  let fixture: ComponentFixture<SpringCampOfferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SpringCampOfferComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SpringCampOfferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
