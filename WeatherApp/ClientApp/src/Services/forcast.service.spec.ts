import { TestBed } from '@angular/core/testing';

import { ForcastService } from './forcast.service';

describe('ForcastService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ForcastService = TestBed.get(ForcastService);
    expect(service).toBeTruthy();
  });
});
