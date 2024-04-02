import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditemployeemodalComponent } from './editemployeemodal.component';

describe('EditemployeemodalComponent', () => {
  let component: EditemployeemodalComponent;
  let fixture: ComponentFixture<EditemployeemodalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditemployeemodalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditemployeemodalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
