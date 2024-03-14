import { TestBed } from '@angular/core/testing';

import { MyfirstserviceService } from './myfirstservice.service';

describe('MyfirstserviceService', () => {
  let service: MyfirstserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MyfirstserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
