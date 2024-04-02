import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EndofServiceComponent } from './endof-service.component';

describe('EndofServiceComponent', () => {
  let component: EndofServiceComponent;
  let fixture: ComponentFixture<EndofServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EndofServiceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EndofServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
