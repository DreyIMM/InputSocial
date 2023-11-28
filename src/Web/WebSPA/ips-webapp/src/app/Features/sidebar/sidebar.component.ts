import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { LocalStorageUtils } from 'src/app/Core/models/localstorage';
import { SidebarService } from 'src/app/Shared/services/sidebar.service';
import { getDatabase, ref } from "firebase/database";
import { onValue } from "firebase/database";

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  localStorageUtils = new LocalStorageUtils();
  nome: string ="";
  bairroMoments:string[] = [];
  public refRealtime = ref;
  public database = getDatabase();

  constructor (private sideBarService : SidebarService, private cdr: ChangeDetectorRef){}


  ngOnInit(): void {
    this.sideBarService.obterFoto();
    this.convertValues();
    this.ArmarzenarUsuario(this.sideBarService.LocalStorage.obterUsuario())
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

  private async BairrosMoments(data: any) {
    data = Object.values(data);
    if (Array.isArray(data)) {
      this.bairroMoments = data.map(item => item.Nome);
    }else {
      console.error('Os dados não são um array.');
    }
  }

  public async convertValues(){
      const starCountRef = this.refRealtime(this.database, "/bairroMoments");
      onValue(starCountRef, (snapshot) => {
        const data = snapshot.val();
        this.BairrosMoments(data)
      });
    ;
  }

}
