import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario, UsuarioLogin } from 'src/app/Core/models/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private htt: HttpClient) { }


  registrarUsuario(usuarioRegistro: Usuario){

  }

  loginUsuario(usuarioRegistro: UsuarioLogin){

  }

}
