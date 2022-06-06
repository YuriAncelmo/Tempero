import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardCategoriaComponent } from './dashboard-categoria.component';

describe('DashboardCategoriaComponent', () => {
  let component: DashboardCategoriaComponent;
  let fixture: ComponentFixture<DashboardCategoriaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DashboardCategoriaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashboardCategoriaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
