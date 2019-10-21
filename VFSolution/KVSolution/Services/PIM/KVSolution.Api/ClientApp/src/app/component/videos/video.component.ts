import { Component } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { NgbdModalConfig } from '../dialogs/modal-config/modal-config';
import { VideoService } from './video.service';

@Component({
  templateUrl: 'card.component.html',
  styleUrls: ['./card.component.scss']
})
export class VideosComponent {

  constructor(private videoService: VideoService, private modalService: NgbModal, private modal : NgbdModalConfig) {
    this.get();
  }

  public get() {
    // let request = new GetBlogsRequest();
    // this.cardService.get(request).subscribe(data => {
    //   console.log(data);
    // });
  }

  public add() {
    this.open("Hello");
  }

  closeResult: string;

  open(content) {
   this.modal.open(content);
  }
}
