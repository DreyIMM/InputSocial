import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-post-add',
  templateUrl: './post-add.component.html',
  styleUrls: ['./post-add.component.css']
})
export class PostAddComponent {
  
  postForm = new FormGroup({
    mensagem: new FormControl('', Validators.maxLength(300)),
    latitude: new FormControl(),
    longitude: new FormControl(),
    bairro: new FormControl(''),
    regiao: new FormControl(''),
  });

  addPost(){

    console.warn(this.postForm.value);

  }

}
