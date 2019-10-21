import { Component } from '@angular/core';
import { CardService } from './card.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { GetBlogsRequest } from './models/blog.model';
import { NgbdModalConfig } from '../dialogs/modal-config/modal-config';

@Component({
  templateUrl: 'card.component.html',
  styleUrls: ['./card.component.scss']
})
export class CardsComponent {

  constructor(private cardService: CardService, private modalService: NgbModal, private modal : NgbdModalConfig) {
    this.get();
  }

  public get() {
    let request = new GetBlogsRequest();

    this.cardService.get(request).subscribe(data => {
      console.log(data);
    });
  }

  public add() {
    this.open("Hello");
  }

  closeResult: string;

  open(content) {
   this.modal.open(content);
  }
}
