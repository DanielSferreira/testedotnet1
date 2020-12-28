import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditarProjComponent } from './editar-proj.component';

describe('EditarProjComponent', () => {
  let component: EditarProjComponent;
  let fixture: ComponentFixture<EditarProjComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditarProjComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditarProjComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
