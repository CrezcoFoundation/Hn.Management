import { Component, Inject, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { FormGroup, FormControl, Validators} from '@angular/forms';

@Component({
  selector: 'app-university-sponsorship',
  templateUrl: './university-sponsorship.component.html',
  styleUrls: ['./university-sponsorship.component.scss'],
})
export class UniversitySponsorshipComponent implements OnInit {
  selectedLanguage = 'en';

  changeLanguage() {
    this.translate.use(this.selectedLanguage);
  }

  form = new FormGroup({
    language: new FormControl('', Validators.required)
  });

  constructor( private translate: TranslateService ) {}

  ngOnInit(): void {

    this.changeLanguage();
  }

  get f(){
    return this.form.controls;
  }
}
