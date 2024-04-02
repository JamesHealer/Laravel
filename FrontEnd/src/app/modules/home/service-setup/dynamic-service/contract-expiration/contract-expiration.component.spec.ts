import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContractExpirationComponent } from './contract-expiration.component';

describe('ContractExpirationComponent', () => {
  let component: ContractExpirationComponent;
  let fixture: ComponentFixture<ContractExpirationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContractExpirationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContractExpirationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
