import { Component } from '@angular/core';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-ngbd-buttons-radio',
  templateUrl: './carousel.component.html',
  styleUrls:['./carousel.component.scss'],
  providers: [NgbCarouselConfig]
})
export class NgbdCarouselBasicComponent {
  showNavigationArrows = false;
  showNavigationIndicators = false;

  images = [1, 2, 3].map(() => `https://picsum.photos/1699/550?random&t=${Math.random()}`);
  
  constructor(config: NgbCarouselConfig) {
    // customize default values of carousels used by this component tree
    config.interval = 10000;
    config.wrap = false;
    config.keyboard = false;

    config.showNavigationArrows = true;
    config.showNavigationIndicators = true;
  }
}
