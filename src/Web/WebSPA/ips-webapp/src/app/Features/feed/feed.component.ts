import { Component, OnInit } from '@angular/core';
import { LocalStorageUtils } from 'src/app/Core/models/localstorage';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css'],
})
export class FeedComponent implements OnInit{
  
  ngOnInit(): void {
    this.usuarioLogado();
  }

  nome: string = "";

  localStorageUtils = new LocalStorageUtils();


  usuarioLogado(){
    this.nome = this.localStorageUtils.obterNome();

    this.buscarFotoUsuarioLogado();

  }

  buscarFotoUsuarioLogado() :string{


    console.log(this.localStorageUtils.obterUsuario().id)
    return "a";
  }


}
