import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpService } from '../shared/services/http.service';
import { AuthService } from './services/auth.service';
import { StorageService } from './services/storage.service';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  declarations: [
    
  ],
  exports: [RouterModule]
})
export class AuthModule {
  static forRoot(): ModuleWithProviders {
    return <ModuleWithProviders>{
      ngModule: AuthModule,
      providers: [HttpService, StorageService]
    };
  }
}
