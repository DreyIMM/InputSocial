import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable, Subject, catchError, map, tap } from 'rxjs';
import { PostagemDetalhe, Postagens } from 'src/app/Core/models/post.models';
import { HttpClient, HttpParams } from '@angular/common/http';
import { getDownloadURL, listAll, ref } from 'firebase/storage';

@Injectable({
  providedIn: 'root'
})
export class PostService extends BaseService {

  private _refreshNeede$ =new Subject<void>();

  get refreshNeedes$(){
    return this._refreshNeede$;
  }

  constructor(private http: HttpClient) { super ();}

  ListagemPostagens() : Observable<Postagens[]>{
      return this.http
      .get<Postagens[]>(this.UrServiceFeed+"feed",this.ObterAuthHeaderJson() )
      .pipe(catchError(this.serviceError));
  }

  PostagemDetalhe(id: string) : Observable<PostagemDetalhe>{
    return this.http
    .get<PostagemDetalhe>(this.UrServiceFeed+"feed/postagem/"+ id,this.ObterAuthHeaderJson() )
    .pipe(catchError(this.serviceError));
  }

  buscarLocalização(lat: number, long : number) : Observable<any>{

    const options =  { params: new HttpParams().append('at', `${lat},${long}`).append('apiKey', 'MO6eW_08JWru-nnOwOltzRRqlI_lkdviY-2GNxfB51g') } ;

    return this.http
      .get<any>(this.UrServiceHere+'revgeocode', options)
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));
  }

  addPost(post : any) : Observable<any>{
        
      return this.http
             .post(this.UrServiceFeed+"feed/postagem", post, this.ObterAuthHeaderJson())
             .pipe(
                tap(() => {
                  this.refreshNeedes$.next();
                }),
                map(this.extractData),
                catchError(this.serviceError));
  }

  addComentario(mensagem: any, idPostagem: string) : Observable<any>{
    return this.http
    .post(this.UrServiceFeed+"feed/postagem/"+idPostagem+"/comentario", mensagem, this.ObterAuthHeaderJson())
    .pipe(
       map(this.extractData),
       tap(() =>{
        this._refreshNeede$.next();
       }),
       catchError(this.serviceError));
  }

  public async obterFoto(post : Postagens): Promise<void> {

    try {
      const listRef = ref(this.storage, '/ipsfotos');
      const items = await listAll(listRef);
  
      for (const itemRef of items.items) {
        if (itemRef.fullPath.includes(post.idUsuario)) {
          const url = await this.obterUrl(itemRef.fullPath);
          if (url) {
            post.imageProfile  = url;
            //document.getElementById(guidUser)?.setAttribute('src', url);
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


}
