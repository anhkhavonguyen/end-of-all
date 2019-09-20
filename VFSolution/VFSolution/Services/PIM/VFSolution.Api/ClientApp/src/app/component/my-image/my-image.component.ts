import { Component } from '@angular/core';
import { UnsplashService } from '../../shared/services/unsplash.service';

@Component({
  templateUrl: 'my-image.component.html'
})
export class MyImageComponent {

  myImage = '';
  myImages = [];
  username = 'e_n_d_o_f_a_l_l';
  bio = '';
  constructor(private unsplashService: UnsplashService) {
    this.bio = this.getUserProfile();
    this.getUnplashImages();
  }

  getUnplashImage() {
    let tempIdImage = 'PJpXEM36QIA';
    let width = 1920;
    let height = 1080;
    let rectangle: Array<number> = [0, 0, 1920, 1080];
    this.unsplashService.GetPhotoById(tempIdImage, width, height, rectangle).then(image => {
      this.myImage = image.urls.full;
    });
  }

  getUnplashImages() {
    this.unsplashService.GetPhotosByUsername(this.username).then(data => {
      this.myImages = data;
    });
  }


  getUserProfile(): string {
    let res = '';
    this.unsplashService.GetUserProfile(this.username).then(data => {
      res = data.bio;
    });
    return res;
  }
}