import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map } from 'rxjs';
import { Usuario, UsuarioLogin } from 'src/app/Core/models/usuario.model';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService  extends BaseService {

  constructor(private http: HttpClient) { super ();}



  registrarUsuario(usuarioRegistro: Usuario) : Observable<Usuario>{
      let response = this.http
      .post(this.UrServiceV1+ 'identidade/nova-conta', usuarioRegistro, this.ObterHeaderJson())
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));

    return response;
  }

  loginUsuario(usuarioLogin: UsuarioLogin) : Observable<UsuarioLogin>{
        let response = this.http
        .post(this.UrServiceV1+ 'identidade/autenticar', usuarioLogin, this.ObterHeaderJson())
        .pipe(
            map(this.extractData),
            catchError(this.serviceError));

        return response;
  }

  NomeUsuario(idGuid: string) : Observable<String>{

    const options = idGuid ? { params: new HttpParams().append('idUsuario', idGuid) } : {};
    let response = this.http
    .get<string>(this.UrServiceUsuario+ 'usuario/nomeusuario', options)
    .pipe(
        map(this.extractData),
        catchError(this.serviceError));

    return response;
  }

}
