import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormdataComponent } from './formdata.component';

describe('FormdataComponent', () => {
  let component: FormdataComponent;
  let fixture: ComponentFixture<FormdataComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FormdataComponent]
    });
    fixture = TestBed.createComponent(FormdataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
