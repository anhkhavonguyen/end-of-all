import { Component } from '@angular/core';
import { UnsplashService } from '../../shared/services/unsplash.service';

@Component({
  templateUrl: 'my-image.component.html'
})
export class MyImageComponent {

  myImage = '';
  constructor(private unsplashService: UnsplashService) {
    this.getUnplashImage();
  }

  getUnplashImage() {
    let tempIdImage = 'PJpXEM36QIA';
    let width = 1920;
    let height = 1080;
    let rectangle: Array<number> = [0, 0, 1920, 1080];
    let tempImage = this.unsplashService.GetImageById(tempIdImage, width, height, rectangle).then(image => {
      this.myImage = image.urls.full;
    });
  }
}