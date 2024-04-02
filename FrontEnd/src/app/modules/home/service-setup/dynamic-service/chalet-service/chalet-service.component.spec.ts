import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChaletServiceComponent } from './chalet-service.component';

describe('ChaletServiceComponent', () => {
  let component: ChaletServiceComponent;
  let fixture: ComponentFixture<ChaletServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChaletServiceComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChaletServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
