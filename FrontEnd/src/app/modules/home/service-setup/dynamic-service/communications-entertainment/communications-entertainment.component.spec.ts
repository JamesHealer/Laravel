import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommunicationsEntertainmentComponent } from './communications-entertainment.component';

describe('CommunicationsEntertainmentComponent', () => {
  let component: CommunicationsEntertainmentComponent;
  let fixture: ComponentFixture<CommunicationsEntertainmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommunicationsEntertainmentComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CommunicationsEntertainmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
