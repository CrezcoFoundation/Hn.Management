import { TestBed } from '@angular/core/testing';

import { ContactEmailsService } from './contact-emails.service';

describe('ContactEmailsService', () => {
  let service: ContactEmailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContactEmailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
