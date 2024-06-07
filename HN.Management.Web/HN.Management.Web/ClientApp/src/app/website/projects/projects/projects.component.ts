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

  form = new FormGroup({
    language: new FormControl('', Validators.required)
  });

  constructor( private translate: TranslateService ){ }

  ngOnInit() {
    Aos.init({
      once: false,
      duration: 800,
      easing: 'ease',
    });
  }
}
