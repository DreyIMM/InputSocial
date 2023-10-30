import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageUtils } from 'src/app/Core/models/localstorage';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent {

  localStorageUtils = new LocalStorageUtils();


  constructor(private router: Router){}

  logout(){
    this.localStorageUtils.limparDadosLocaisUsuario();
    this.router.navigate(['/']);
  
  }

}
