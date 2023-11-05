import { Component, OnInit } from '@angular/core';
import { LocalStorageUtils } from 'src/app/Core/models/localstorage';
import { SidebarService } from 'src/app/Shared/services/sidebar.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  
  localStorageUtils = new LocalStorageUtils();
  nome: string ="";

  constructor (private sideBarService : SidebarService){}


  ngOnInit(): void {

    this.sideBarService.obterFoto();
    
    if (typeof this.nome === 'string' && this.nome.length === 0) {
      this.ArmarzenarUsuario(this.sideBarService.LocalStorage.obterUsuario())
    }

  }

  ArmarzenarUsuario(result: any) {
    this.sideBarService.NomeUsuario(result.id)
      .subscribe(
        (v) => {
          this.sideBarService.LocalStorage.salvaNomeUsuaio(v);
          this.nome = this.localStorageUtils.obterNome();
        },
        (e) => {
          console.error('Erro ao armazenar o nome de usuário:', e);
        }
      );
      
        
  }


}
