import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import Aos from 'aos';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss'],
})
export class ProjectsComponent implements OnInit {


  /* selectedLanguage = 'es';

  changeLanguage() {
    this.translate.use(this.selectedLanguage);
  }

  form = new FormGroup({
    language: new FormControl('', Validators.required)
  });

  constructor(
    private translate: TranslateService,
  ) {} */

  ngOnInit() {
    /* this.changeLanguage(); */

    Aos.init({
      once: false,
      duration: 800,
      easing: 'ease',
    });
  }
}
