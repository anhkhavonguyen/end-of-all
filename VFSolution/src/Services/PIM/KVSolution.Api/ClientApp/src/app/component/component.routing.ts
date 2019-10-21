import { Routes } from '@angular/router';

import { CardsComponent } from './card/card.component';
import { MyImageComponent } from './my-image/my-image.component';
import { NgbdtabsBasicComponent } from './tabs/tabs.component';

export const ComponentsRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'cards',
        component: CardsComponent,
        data: {
          title: 'Blogs',
          urls: [
            { title: 'Dashboard', url: '/dashboard' },
            { title: 'Reading' },
            { title: 'Blogs' }
          ]
        }
      },
      {
        path: 'my-images',
        component: MyImageComponent,
        data: {
          title: 'Unsplash',
          urls: [
            { title: 'Unsplash', url: '/dashboard' }
          ]
        }
      },
      {
        path: 'stories',
        component: NgbdtabsBasicComponent,
        data: {
          title: 'Stories',
          urls: [
            { title: 'Stories' }
          ]
        }
      }
    ]
  }
];
