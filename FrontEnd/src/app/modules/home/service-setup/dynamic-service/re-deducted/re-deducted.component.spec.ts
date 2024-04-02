import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReDeductedComponent } from './re-deducted.component';

describe('ReDeductedComponent', () => {
  let component: ReDeductedComponent;
  let fixture: ComponentFixture<ReDeductedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReDeductedComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReDeductedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
