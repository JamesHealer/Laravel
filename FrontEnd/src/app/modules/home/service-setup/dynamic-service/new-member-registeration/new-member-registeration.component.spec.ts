import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewMemberRegisterationComponent } from './new-member-registeration.component';

describe('NewMemberRegisterationComponent', () => {
  let component: NewMemberRegisterationComponent;
  let fixture: ComponentFixture<NewMemberRegisterationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewMemberRegisterationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewMemberRegisterationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
