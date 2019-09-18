import { Component } from '@angular/core';
import { MyImageService } from './my-image.service';
@Component({
  templateUrl: 'my-image.component.html'
})
export class MyImageComponent {

  constructor(private myImageService: MyImageService) {
    let temp = myImageService.GetImage();
  }
}
