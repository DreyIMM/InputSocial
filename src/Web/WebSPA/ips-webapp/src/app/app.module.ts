import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { LoginComponent } from './Features/Login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { LoginService } from './Shared/services/login.service';
import { PasswordPatternDirective } from './Shared/directives/password-pattern.directive';
import { MatchPasswordDirective } from './Shared/directives/match-password.directive';
import { SidebarComponent } from './Features/sidebar/sidebar.component';
import { FooterComponent } from './Features/footer/footer.component';
import { NavbarComponent } from './Features/Navbar/navbar.component';
import { FeedComponent } from './Features/feed/feed.component';
import { AppComponent } from './Features/app.component';
import { AppRoutingModule } from './app-routing-module';

@NgModule({
  declarations: [
    LoginComponent,
    PasswordPatternDirective,
    MatchPasswordDirective,
    NavbarComponent,
    FeedComponent,
    SidebarComponent,
    FooterComponent,
    AppComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    LoginService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
