import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddemployeeinformationComponent } from './addemployeeinformation.component';

describe('AddemployeeinformationComponent', () => {
  let component: AddemployeeinformationComponent;
  let fixture: ComponentFixture<AddemployeeinformationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddemployeeinformationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddemployeeinformationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
