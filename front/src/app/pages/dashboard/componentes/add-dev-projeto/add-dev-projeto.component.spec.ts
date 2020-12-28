import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDevProjetoComponent } from './add-dev-projeto.component';

describe('AddDevProjetoComponent', () => {
  let component: AddDevProjetoComponent;
  let fixture: ComponentFixture<AddDevProjetoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDevProjetoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDevProjetoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
