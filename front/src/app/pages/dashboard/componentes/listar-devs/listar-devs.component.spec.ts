import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarDevsComponent } from './listar-devs.component';

describe('ListarDevsComponent', () => {
  let component: ListarDevsComponent;
  let fixture: ComponentFixture<ListarDevsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListarDevsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListarDevsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
