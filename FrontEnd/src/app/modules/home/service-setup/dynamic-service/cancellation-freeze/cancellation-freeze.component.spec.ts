import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CancellationFreezeComponent } from './cancellation-freeze.component';

describe('CancellationFreezeComponent', () => {
  let component: CancellationFreezeComponent;
  let fixture: ComponentFixture<CancellationFreezeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CancellationFreezeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CancellationFreezeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
