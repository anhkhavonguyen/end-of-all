import { Component } from '@angular/core';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CardService } from '../card.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { BlogRequest, BlogModel } from '../models/blog.model';

@Component({
  selector: 'add-blog',
  templateUrl: './add-blog.html',
  styleUrls: ['./add-blog.scss'],
  providers: [NgbModalConfig, NgbModal]
})
export class AddBlog {

  contactForm: FormGroup;
  constructor(config: NgbModalConfig, private modalService: NgbModal, private cardService: CardService, private formBuilder: FormBuilder) {
    config.backdrop = 'static';
    config.keyboard = false;

    this.createContactForm();
  }

  open(content) {
    this.modalService.open(content);
  }

  onSave() {

  }

  createContactForm() {
    this.contactForm = this.formBuilder.group({
      title: [''],
      text: [''],
      link: [''],
      categoryId: ['']
    });
  }

  onSubmit() {
    console.log('Your form data : ', this.contactForm.value);
    let request: BlogRequest = {
      blogModel: {
        link: this.contactForm.value.link,
        text: this.contactForm.value.text,
        title: this.contactForm.value.title,
        categoryId: this.contactForm.value.categoryId
      }
    };

    this.cardService.add(request).subscribe(data => {
      console.log(data);
    })
  }
}