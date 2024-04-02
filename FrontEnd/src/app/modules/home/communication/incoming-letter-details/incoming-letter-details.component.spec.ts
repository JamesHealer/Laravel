import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IncomingLetterDetailsComponent } from './incoming-letter-details.component';

describe('IncomingLetterDetailsComponent', () => {
  let component: IncomingLetterDetailsComponent;
  let fixture: ComponentFixture<IncomingLetterDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IncomingLetterDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IncomingLetterDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
