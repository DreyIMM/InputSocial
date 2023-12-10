import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { HttpClient, HttpParams } from '@angular/common/http';
import {  ref, listAll, getDownloadURL } from 'firebase/storage';
import { Observable, Subject, catchError, map, tap } from 'rxjs';
import { onValue } from "firebase/database";


@Injectable({
  providedIn: 'root'
})
export class SidebarService extends BaseService{

  constructor(private http: HttpClient) { super ();}

  public async obterFoto(): Promise<void> {

    try {
      const guidUser: any = this.LocalStorage.obterUsuario();
      const listRef = ref(this.storage, '/ipsfotos');
      const items = await listAll(listRef);
  
      for (const itemRef of items.items) {
        if (itemRef.fullPath.includes(guidUser.id)) {
          const url = await this.obterUrl(itemRef.fullPath);
          if (url) {
            document.getElementById('profileLogao')?.setAttribute('src', url);
          }
          break; 
        }
      }
    } catch (error) {
      console.error('Erro ao obter foto:', error);
    }
    
  }
  
  protected async obterUrl(urlPhoto: string): Promise<string> {
    try {
      const url = await getDownloadURL(ref(this.storage, urlPhoto));
      return url;
    } catch (error) {
      console.error('Erro ao obter URL da imagem:', error);
      return '';
    }
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
