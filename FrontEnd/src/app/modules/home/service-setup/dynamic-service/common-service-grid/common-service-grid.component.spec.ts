import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommonServiceGridComponent } from './common-service-grid.component';

describe('CommonServiceGridComponent', () => {
  let component: CommonServiceGridComponent;
  let fixture: ComponentFixture<CommonServiceGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommonServiceGridComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CommonServiceGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
