import { Component, OnInit } from '@angular/core';
import {
  StoryAdminInterface,
  StoryInformation,
  getInfoAdminObject,
  getStoryInfoObject,
} from '../data-story';

@Component({
  selector: 'app-crezco-story',
  templateUrl: './crezco-story.component.html',
  styleUrls: ['./crezco-story.component.scss'],
})
export class CrezcoStoryComponent implements OnInit {

  showCarousel: boolean = false;

  infoGraduates: StoryInformation[];
  infoAdmin: StoryAdminInterface[];
  constructor() {
    this.infoGraduates = getStoryInfoObject().reverse();
    this.infoAdmin = getInfoAdminObject();
  }

  ngOnInit(): void {
    // Detectar el tamaño de la pantalla y establecer showCarousel en consecuencia
    this.detectScreenSize();
    window.addEventListener('resize', () => {
      this.detectScreenSize();
    });
  }

  detectScreenSize() {
    if (window.innerWidth >= 992) {
      this.showCarousel = true; // Mostrar en pantallas grandes (>= 992px)
    } else {
      this.showCarousel = false; // Ocultar en pantallas pequeñas (< 992px)
    }
  }
}
