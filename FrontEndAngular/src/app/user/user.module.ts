import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserAccountComponent } from './user-account/user-account.component';
import { UserDataComponent } from './user-data/user-data.component';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    UserAccountComponent
  ],
  declarations: [
    UserAccountComponent,
    UserDataComponent
  ]
})
export class UserModule { }
