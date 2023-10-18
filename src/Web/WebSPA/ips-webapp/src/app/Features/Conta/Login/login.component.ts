import { Component, OnInit } from '@angular/core';
import { Usuario, UsuarioLogin, UsuarioRespostaLogin } from 'src/app/Core/models/usuario.model';
import { LoginService } from 'src/app/Shared/services/login.service';
@Component({
  selector: 'app-root',
  templateUrl: './login.component.html',
   styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  
  constructor ( 
     private loginService : LoginService
    
     ){}

  

  signupObj: Usuario = { 
    UserName: '',
    Celular: '',
    Nascimento  : '',
    Email : '',
    Senha : '',
    SenhaConfirmacao : ''
  }

  login : UsuarioLogin =  new UsuarioLogin();

  loginObj: any = {
    Email : '',
    Senha: '',
  };
   
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
    
    this.login.Email = this.loginObj.Email;
    this.login.Senha = this.loginObj.Senha;

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
