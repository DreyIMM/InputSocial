import { Component, OnDestroy, OnInit } from '@angular/core';
import { Postagens } from 'src/app/Core/models/post.models';
import { PostService } from 'src/app/Shared/services/post.service';
@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['../.././feed/./feed.component.css']
})
export class PostListComponent implements OnInit{
  
  constructor(private postService: PostService) { }

  public postagens: Postagens[] = [new Postagens()];

  ngOnInit(): void {
      this.postService.refreshNeedes$.subscribe(()=>{
        this.ObterPostagens();
      });
      this.ObterPostagens();
  }



  public ObterPostagens(): void {
    this.postService.ListagemPostagens().subscribe({
      next: (v) => {
        this.postagens = v;
        this.postagens.forEach(p => {
          this.postService.obterFoto(p);
        }) 
      },
      error: (e) => {
        console.log(e);
      },
      complete: () => {
        console.info('complete');
      },
    });
  }

}
