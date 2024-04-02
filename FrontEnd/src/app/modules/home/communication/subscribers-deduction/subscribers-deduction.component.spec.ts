import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubscribersDeductionComponent } from './subscribers-deduction.component';

describe('SubscribersDeductionComponent', () => {
  let component: SubscribersDeductionComponent;
  let fixture: ComponentFixture<SubscribersDeductionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubscribersDeductionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SubscribersDeductionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
