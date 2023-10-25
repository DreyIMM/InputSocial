import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario, UsuarioLogin, UsuarioRespostaLogin } from 'src/app/Core/models/usuario.model';
import { LoginService } from 'src/app/Shared/services/login.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  
  constructor (private loginService : LoginService, private router: Router){}
  
  errors : any[] = [];
  signupObj: Usuario = new Usuario()
  login : UsuarioLogin =  new UsuarioLogin();

  ngOnInit(): void {
   
  } 

  onSignUp(){
    this.loginService.registrarUsuario(this.signupObj)
    .subscribe({
      next: (v) => this.processarSucesso(v),
      error: (e) => this.processarFalha(e),
      complete: () => console.info('complete')
    }); 

  }

  onLogin(){

    this.loginService.loginUsuario(this.login)
    .subscribe({
      next: (v) => this.processarSucesso(v),
      error: (e) => this.processarFalha(e),
      complete: () => console.info('complete') 
  })
    
  
  }

  processarSucesso(response : any){
      this.errors = [];

      //armazenando o token, ou seja, o usuario está logado
      this.loginService.LocalStorage.salvarDadosLocaisUsuario(response);
      this.router.navigate(['/feed'])
  }

  processarFalha(fail : any){
      this.errors = fail.error.errors.Mensagens;
  }
  

}
