import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { StarterComponent } from './starter.component';
import { NgbdCarouselBasicComponent } from './components/carousel/carousel.component';

const routes: Routes = [
  {
    path: '',
    data: {
      title: 'Starter Page',
      urls: [
        { title: 'Dashboard', url: '/dashboard' },
        { title: 'Starter Page' }
      ]
    },
    component: StarterComponent
  }
];

@NgModule({
  imports: [FormsModule, CommonModule, RouterModule.forChild(routes),NgbModule],
  declarations: [StarterComponent,NgbdCarouselBasicComponent]
})
export class StarterModule {}
