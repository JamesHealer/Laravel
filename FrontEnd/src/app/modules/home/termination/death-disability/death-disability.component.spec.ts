import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeathDisabilityComponent } from './death-disability.component';

describe('DeathDisabilityComponent', () => {
  let component: DeathDisabilityComponent;
  let fixture: ComponentFixture<DeathDisabilityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeathDisabilityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeathDisabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
