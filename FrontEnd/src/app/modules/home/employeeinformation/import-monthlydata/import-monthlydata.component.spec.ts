import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImportMonthlyDataComponent } from './import-monthlydata.component';

describe('ImportMonthlyDataComponent', () => {
  let component: ImportMonthlyDataComponent;
  let fixture: ComponentFixture<ImportMonthlyDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ImportMonthlyDataComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ImportMonthlyDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
