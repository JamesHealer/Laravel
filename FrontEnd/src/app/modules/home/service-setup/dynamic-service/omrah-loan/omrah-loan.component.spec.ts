import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OmrahLoanComponent } from './omrah-loan.component';

describe('OmrahLoanComponent', () => {
  let component: OmrahLoanComponent;
  let fixture: ComponentFixture<OmrahLoanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OmrahLoanComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OmrahLoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
