import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarDevComponent } from './editar-dev.component';

describe('EditarDevComponent', () => {
  let component: EditarDevComponent;
  let fixture: ComponentFixture<EditarDevComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditarDevComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarDevComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
