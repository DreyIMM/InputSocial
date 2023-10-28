import { Component, OnInit } from '@angular/core';
import { Postagens } from 'src/app/Core/models/post.models';
import { PostService } from 'src/app/Shared/services/post.service';
@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['../.././feed/./feed.component.css']
})
export class PostListComponent implements OnInit{
  
  constructor(private postService: PostService) { }

  public postagens: Postagens[];

  ngOnInit(): void {
    
    this.postService.ListagemPostagens().
    subscribe(
      post => this.postagens = post,
      error => console.log(error));
  }



}
