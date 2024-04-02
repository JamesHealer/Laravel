import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TouristLeisureTripComponent } from './tourist-leisure-trip.component';

describe('TouristLeisureTripComponent', () => {
  let component: TouristLeisureTripComponent;
  let fixture: ComponentFixture<TouristLeisureTripComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TouristLeisureTripComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TouristLeisureTripComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
