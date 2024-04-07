import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentformComponent } from './parentform.component';

describe('ParentformComponent', () => {
  let component: ParentformComponent;
  let fixture: ComponentFixture<ParentformComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ParentformComponent]
    });
    fixture = TestBed.createComponent(ParentformComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
