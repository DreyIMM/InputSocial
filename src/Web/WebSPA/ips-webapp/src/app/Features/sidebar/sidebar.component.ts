import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
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
  bairroMoments:string[] = [];
  constructor (private sideBarService : SidebarService,  private cdr: ChangeDetectorRef){}


  ngOnInit(): void {

    this.sideBarService.obterFoto();
    
    if (typeof this.nome === 'string' && this.nome.length === 0) {
      this.ArmarzenarUsuario(this.sideBarService.LocalStorage.obterUsuario())
    }

    this.sideBarService.refreshNeeded$.subscribe(() =>{
      this.BairrosMoments();
    })
    this.BairrosMoments();
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

  private async BairrosMoments() {
    const data = await this.sideBarService.obterMomentsFirebase();
    if (Array.isArray(data)) {
      this.bairroMoments = data.map(item => item.Nome);
      this.cdr.detectChanges(); 
      console.log(this.bairroMoments)
    }else {
      console.error('Os dados não são um array.');
    }}

}
