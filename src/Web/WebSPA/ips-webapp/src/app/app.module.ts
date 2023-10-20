import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { LoginComponent } from './Features/Login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { LoginService } from './Shared/services/login.service';
import { PasswordPatternDirective } from './Shared/directives/password-pattern.directive';
import { MatchPasswordDirective } from './Shared/directives/match-password.directive';

@NgModule({
  declarations: [
    LoginComponent,
    PasswordPatternDirective,
    MatchPasswordDirective,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [
    LoginService
  ],
  bootstrap: [LoginComponent]
})
export class AppModule { }
