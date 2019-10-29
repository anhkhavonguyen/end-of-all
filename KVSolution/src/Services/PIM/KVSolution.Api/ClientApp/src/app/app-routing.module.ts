import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { FullComponent } from './layouts/full/full.component';
import { AuthGuardService } from './auth/services/auth-guard.service';

export const Approutes: Routes = [
  {
    path: '',
    component: FullComponent,
    children: [
      { path: '', redirectTo: '/about', pathMatch: 'full' },
      {
        path: 'about',
        loadChildren: () => import('./starter/starter.module').then(m => m.StarterModule),
        //canActivate: [AuthGuardService],
      },
      {
        path: 'component',
        loadChildren: () => import('./component/component.module').then(m => m.ComponentsModule),
        //canActivate: [AuthGuardService],
      },
    ]
  },
  {
    path: '**',
    redirectTo: '/about'
  }
];
