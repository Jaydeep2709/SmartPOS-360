import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InventoryAlert } from './inventory-alert';

describe('InventoryAlert', () => {
  let component: InventoryAlert;
  let fixture: ComponentFixture<InventoryAlert>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InventoryAlert]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InventoryAlert);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
