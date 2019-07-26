import { TestBed } from '@angular/core/testing';

import { ToppingsService } from './toppings.service';

describe('ToppingsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ToppingsService = TestBed.get(ToppingsService);
    expect(service).toBeTruthy();
  });
});
