import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YearlyProcessComponent } from './yearly-process.component';

describe('YearlyProcessComponent', () => {
  let component: YearlyProcessComponent;
  let fixture: ComponentFixture<YearlyProcessComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YearlyProcessComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(YearlyProcessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
