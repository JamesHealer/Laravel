import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddAllTheServicesComponent } from './add-all-the-services.component';

describe('AddAllTheServicesComponent', () => {
  let component: AddAllTheServicesComponent;
  let fixture: ComponentFixture<AddAllTheServicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddAllTheServicesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddAllTheServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
