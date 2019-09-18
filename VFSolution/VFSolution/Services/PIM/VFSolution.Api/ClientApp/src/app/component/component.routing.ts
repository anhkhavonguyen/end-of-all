import { Routes } from '@angular/router';

import { CardsComponent } from './card/card.component';
import { MyImageComponent } from './my-image/my-image.component';

export const ComponentsRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'cards',
        component: CardsComponent,
        data: {
          title: 'Cards',
          urls: [
            { title: 'Dashboard', url: '/dashboard' },
            { title: 'ngComponent' },
            { title: 'Cards' }
          ]
        }
      },
      {
        path: 'my-images',
        component: MyImageComponent,
        data: {
          title: 'My Images',
          urls: [
            { title: 'My Images', url: '/dashboard' }
          ]
        }
      },
    ]
  }
];
