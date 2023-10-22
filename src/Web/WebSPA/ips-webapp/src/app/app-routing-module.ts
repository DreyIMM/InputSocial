import { NgModule } from "@angular/core";
import {Routes, RouterModule} from "@angular/router";
import { LoginComponent } from "./Features/Login/login.component";
import { FeedComponent } from "./Features/feed/feed.component";

const routes: Routes = [
    {path: '', redirectTo: '/login', pathMatch: 'full'},
    {path: 'login', component: LoginComponent},
    {path: 'feed', component: FeedComponent}
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })

export class AppRoutingModule { }