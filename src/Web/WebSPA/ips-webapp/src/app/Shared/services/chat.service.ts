import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, catchError, switchMap } from 'rxjs';
import { Usuarios } from 'src/app/Core/models/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class ChatService extends  BaseService {

  databasechat = this.database;

  constructor(private http: HttpClient) { super ();}

  todoUsuarios() : Observable<Usuarios[]>{
    return this.http
    .get<Usuarios[]>(this.UrServiceUsuario+"usuario/usuarios",this.ObterHeaderJson() )
    .pipe(catchError(this.serviceError));
  }


  
}


