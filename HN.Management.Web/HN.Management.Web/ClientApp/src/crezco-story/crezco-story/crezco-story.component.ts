import { Component } from '@angular/core';
import {
  StoryAdminInterface,
  StoryInformationInterface,
  getInfoAdminObject,
  getStoryInfoObject,
} from '../data-story';

@Component({
  selector: 'app-crezco-story',
  templateUrl: './crezco-story.component.html',
  styleUrls: ['./crezco-story.component.scss'],
})
export class CrezcoStoryComponent {
  storyInfo: StoryInformationInterface[];
  storyInfoAdmin: StoryAdminInterface[];
  constructor() {
    this.storyInfo = getStoryInfoObject();
    this.storyInfoAdmin = getInfoAdminObject();
  }
}
