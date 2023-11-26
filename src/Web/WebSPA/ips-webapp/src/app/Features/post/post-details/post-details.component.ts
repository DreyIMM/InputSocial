import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Comentario, PostagemDetalhe } from 'src/app/Core/models/post.models';
import { PostService } from 'src/app/Shared/services/post.service';

@Component({
  selector: 'app-post-details',
  templateUrl: './post-details.component.html',
  styleUrls: ['../.././feed/./feed.component.css']
})
export class PostDetailsComponent{

  constructor(
     private route: ActivatedRoute,
     private postService: PostService,
     private router: Router,
     ) {
    this.postDetails = this.route.snapshot.data['post'];
  }

  postDetails: PostagemDetalhe
  postForm = new FormGroup({
    mensagem: new FormControl('', Validators.minLength(5)),
  });

 
  

  enviarComentario(idPostagem:string){

    debugger
    if(this.postForm.dirty && this.postForm.valid){

      var comentario = new Comentario(this.postForm.value.mensagem);
      this.postService.addComentario(comentario,idPostagem).subscribe({ 
        next: (s) => {this.cleanRefrehs(idPostagem)},
        error: (e) => console.log(e),
        complete: () => console.log('resquet complete')
      })
    }
      
  }
  

  cleanRefrehs(idPostagem: string) {
    this.postForm.reset();
    this.router.navigate(['/feed'])
  }
}


