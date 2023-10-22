import { Component, OnInit } from '@angular/core';
import { Usuario, UsuarioLogin, UsuarioRespostaLogin } from 'src/app/Core/models/usuario.model';
import { LoginService } from 'src/app/Shared/services/login.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  
  constructor ( 
     private loginService : LoginService
    
     ){}

  

  signupObj: Usuario = new Usuario()

  login : UsuarioLogin =  new UsuarioLogin();

  ngOnInit(): void {
   
  } 

  onSignUp(){
    debugger
    this.loginService.registrarUsuario(this.signupObj)
    .subscribe({
      next: (v) => this.processarSucesso(v),
      error: (e) => this.processarFalha,
      complete: () => console.info('complete')
    }); 

  }

  onLogin(){

    this.loginService.loginUsuario(this.login)
    .subscribe({
      next: (v) => this.processarSucesso(v),
      error: (e) => this.processarFalha,
      complete: () => console.info('complete') 
  })
    
  
  }

  processarSucesso(response : any){

  }

  processarFalha(response : any){
    
  }
  

}
