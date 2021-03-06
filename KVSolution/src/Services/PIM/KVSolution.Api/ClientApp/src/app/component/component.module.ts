import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { ComponentsRoutes } from './component.routing';
import { NgbdpregressbarBasicComponent } from './progressbar/progressbar.component';
import { NgbdpaginationBasicComponent } from './pagination/pagination.component';
import { NgbdAccordionBasicComponent } from './accordion/accordion.component';
import { NgbdAlertBasicComponent } from './alert/alert.component';
import { NgbdDatepickerBasicComponent } from './datepicker/datepicker.component';
import { NgbdDropdownBasicComponent } from './dropdown-collapse/dropdown-collapse.component';
import { NgbdModalBasicComponent } from './modal/modal.component';
import { NgbdPopTooltipComponent } from './popover-tooltip/popover-tooltip.component';
import { NgbdratingBasicComponent } from './rating/rating.component';
import { NgbdtabsBasicComponent } from './tabs/tabs.component';
import { NgbdtimepickerBasicComponent } from './timepicker/timepicker.component';
import { NgbdtypeheadBasicComponent } from './typehead/typehead.component';
import { ButtonsComponent } from './buttons/buttons.component';
import { CardsComponent } from './card/card.component';
import { MyImageComponent } from './my-image/my-image.component';
import { MyImageService } from './my-image/my-image.service';
import { SharedModule } from '../shared/shared.module';
import { UnsplashService } from '../shared/services/unsplash.service';
import { ContentService } from './tabs/content.component.service';
import { CardService } from './card/card.service';
import { NgbdModalConfig } from './dialogs/modal-config/modal-config';
import { AddBlog } from './card/add-blog/add-blog';
import { CryptocurrencyService } from './cryptocurrency/cryptocurrency.service';
import { CryptocurrenciesComponent } from './cryptocurrency/cryptocurrency.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(ComponentsRoutes),
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    SharedModule
  ],
  declarations: [
    NgbdpregressbarBasicComponent,
    NgbdpaginationBasicComponent,
    NgbdAccordionBasicComponent,
    NgbdAlertBasicComponent,
    NgbdDatepickerBasicComponent,
    NgbdDropdownBasicComponent,
    NgbdModalBasicComponent,
    NgbdPopTooltipComponent,
    NgbdratingBasicComponent,
    NgbdtabsBasicComponent,
    NgbdtimepickerBasicComponent,
    NgbdtypeheadBasicComponent,
    ButtonsComponent,
    CardsComponent,
    MyImageComponent,
    NgbdModalConfig,
    AddBlog,
    CryptocurrenciesComponent
  ],
  providers: [
    MyImageService,
    UnsplashService,
    ContentService,
    CardService,
    NgbdModalConfig,
    AddBlog,
    CryptocurrencyService
  ],
  exports: [NgbdModalConfig,AddBlog],
})
export class ComponentsModule { }
