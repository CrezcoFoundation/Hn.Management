import { Component } from '@angular/core';
import {
  CrezcoInformationInteface,
  getCrezcoInformationObjet,
} from '../data/crezco-information';
@Component({
  selector: 'app-full-page-carousel',
  templateUrl: './full-page-carousel.component.html',
  styleUrls: ['./full-page-carousel.component.scss'],
})
export class FullPageCarouselComponent {
  crezcoInfo: CrezcoInformationInteface[];
  constructor() {
    this.crezcoInfo = getCrezcoInformationObjet();
    console.log(this.crezcoInfo);
  }
}
