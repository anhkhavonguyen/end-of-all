import { Component } from '@angular/core';
import { NgbTabChangeEvent } from '@ng-bootstrap/ng-bootstrap';
import { ContentService } from './content.component.service';

@Component({
  selector: 'app-ngbd-tabs',
  templateUrl: './tabs.component.html'
})
export class NgbdtabsBasicComponent {
  currentJustify = 'start';

  currentOrientation = 'horizontal';
  public beforeChange($event: NgbTabChangeEvent) {
    if ($event.nextId === 'tab-preventchange2') {
      $event.preventDefault();
    }
  }

  constructor(private contentService: ContentService) {
    //this.load();
  }

  load() {
    this.contentService.get().subscribe(res => {
      console.log(res);
    });
  }
}
