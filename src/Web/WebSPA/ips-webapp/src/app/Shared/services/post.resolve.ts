import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { PostagemDetalhe } from "src/app/Core/models/post.models";
import { PostService } from "./post.service";

@Injectable()
export class PostResolve implements Resolve<PostagemDetalhe> {

    constructor(private postagemService: PostService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return  this.postagemService.PostagemDetalhe(route.params['id']);
    }
}