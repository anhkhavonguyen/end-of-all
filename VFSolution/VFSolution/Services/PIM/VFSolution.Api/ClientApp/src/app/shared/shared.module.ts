import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpService } from './services/http.service';


@NgModule({
  imports: [
    CommonModule,
  ],
  providers: [HttpService],
  exports: [ CommonModule, FormsModule ],
})
export class SharedModule { }
