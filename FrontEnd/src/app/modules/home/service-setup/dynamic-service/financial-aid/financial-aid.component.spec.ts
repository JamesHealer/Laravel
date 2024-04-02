import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FinancialAidComponent } from './financial-aid.component';

describe('FinancialAidComponent', () => {
  let component: FinancialAidComponent;
  let fixture: ComponentFixture<FinancialAidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FinancialAidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FinancialAidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
