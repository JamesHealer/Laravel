import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeathHealthDisabilityComponent } from './death-health-disability.component';

describe('DeathHealthDisabilityComponent', () => {
  let component: DeathHealthDisabilityComponent;
  let fixture: ComponentFixture<DeathHealthDisabilityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeathHealthDisabilityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeathHealthDisabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
