import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NovoDevComponent } from './novo-dev.component';

describe('NovoDevComponent', () => {
  let component: NovoDevComponent;
  let fixture: ComponentFixture<NovoDevComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NovoDevComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NovoDevComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
