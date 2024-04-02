import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyServicesComponent } from './modify-services.component';

describe('ModifyServicesComponent', () => {
  let component: ModifyServicesComponent;
  let fixture: ComponentFixture<ModifyServicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModifyServicesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModifyServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
