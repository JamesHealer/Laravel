import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReturnAReservedAmountComponent } from './return-a-reserved-amount.component';

describe('ReturnAReservedAmountComponent', () => {
  let component: ReturnAReservedAmountComponent;
  let fixture: ComponentFixture<ReturnAReservedAmountComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReturnAReservedAmountComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReturnAReservedAmountComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
