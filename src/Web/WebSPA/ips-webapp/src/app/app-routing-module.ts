import { NgModule } from "@angular/core";
import {Routes, RouterModule} from "@angular/router";
import { LoginComponent } from "./Features/Login/login.component";
import { FeedComponent } from "./Features/feed/feed.component";
import { AuthGuard } from "./Shared/services/DomainsGuard ";
import { NotFoundComponent } from "./Features/not-found/not-found.component";
import { PostDetailsComponent } from "./Features/post/post-details/post-details.component";
import { PostResolve } from "./Shared/services/post.resolve";

const routes: Routes = [
    {path: '', redirectTo: '/login', pathMatch: 'full'},
    {path: 'login',component: LoginComponent},
    {path: 'feed', canActivate: [AuthGuard] , component: FeedComponent},
    {path: 'detalhes/:id', component: PostDetailsComponent, resolve:{ post : PostResolve}},
    {path: '**', component: NotFoundComponent}
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })

export class AppRoutingModule { }