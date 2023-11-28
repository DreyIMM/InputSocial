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
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import {MatListModule} from '@angular/material/list';
import { NotFoundComponent } from './Features/not-found/not-found.component';
import {MatIconModule} from '@angular/material/icon';
import {MatMenuModule} from '@angular/material/menu';
import { PostListComponent } from './Features/post/post-list/post-list.component';
import { PostAddComponent } from './Features/post/post-add/post-add.component';
import {MatTabsModule} from '@angular/material/tabs';
import { PostDetailsComponent } from './Features/post/post-details/post-details.component';
import { PostResolve } from './Shared/services/post.resolve';
import { MatBadgeModule } from '@angular/material/badge';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NgxMaskDirective, NgxMaskPipe, provideNgxMask } from 'ngx-mask';
@NgModule({
  declarations: [
    LoginComponent,
    PasswordPatternDirective,
    MatchPasswordDirective,
    NavbarComponent,
    FeedComponent,
    SidebarComponent,
    FooterComponent,
    AppComponent,
    NotFoundComponent,
    PostListComponent,
    PostAddComponent,
    PostDetailsComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatCardModule,
    MatButtonModule,
    MatListModule,
    MatMenuModule,
    MatIconModule,
    MatTabsModule,
    MatBadgeModule,
    MatInputModule,
    MatFormFieldModule,
    NgxMaskDirective,
    NgxMaskPipe
  ],
  providers: [
    PostResolve,
    LoginService,
    provideNgxMask()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
