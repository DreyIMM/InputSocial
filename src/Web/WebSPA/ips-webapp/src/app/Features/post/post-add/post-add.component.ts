import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Postagem } from 'src/app/Core/models/post.models';
import { PostService } from 'src/app/Shared/services/post.service';

@Component({
  selector: 'app-post-add',
  templateUrl: './post-add.component.html',
  styleUrls: ['./post-add.component.css']
})
export class PostAddComponent {
  
  constructor(private postService: PostService) {}

  postForm = new FormGroup({
    mensagem: new FormControl('', Validators.maxLength(300)),
    latitude: new FormControl(),
    longitude: new FormControl(),
    bairro: new FormControl(''),
    regiao: new FormControl(''),
  });

  async addPost() {
    try {
      const position = await this.getCurrentPositionAsync();
      await this.setGeoProcess(position);
      const addPost = await this.SendPost(this.postForm);
    } catch (error) {
      console.error(error);
    }
  }
  
  getCurrentPositionAsync(): Promise<any> {
    return new Promise((resolve, reject) => {
      navigator.geolocation.getCurrentPosition(resolve, reject);
    });
  }
  
  async setGeoProcess(position: any) {
    try {

      const v = await this.postService.buscarLocalização(position.coords.latitude, position.coords.longitude).toPromise();

      const updatedValues = {
        bairro: v.items[0].address.district,
        regiao: v.items[0].address.city,
        latitude: position.coords.latitude,
        longitude: position.coords.longitude
      };
      this.postForm.patchValue(updatedValues);

    } catch (e) {
      throw e;
    }
  }

  async SendPost (valuepost : any){
    const postagem = new Postagem(valuepost.value.mensagem, valuepost.value.bairro, valuepost.value.regiao, valuepost.value.latitude, valuepost.value.longitude);

    this.postService.addPost(postagem).subscribe({
      next: (s) => console.log(s),
      error: (e) => console.log(e),
      complete: () => console.log('resquet complete')
    })
  }
}
