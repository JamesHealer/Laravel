import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneralAssemblyReportComponent } from './general-assembly-report.component';

describe('GeneralAssemblyReportComponent', () => {
  let component: GeneralAssemblyReportComponent;
  let fixture: ComponentFixture<GeneralAssemblyReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GeneralAssemblyReportComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GeneralAssemblyReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
