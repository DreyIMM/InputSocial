import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable, Subject, catchError, map, tap } from 'rxjs';
import { PostagemDetalhe, Postagens } from 'src/app/Core/models/post.models';
import { HttpClient, HttpParams } from '@angular/common/http';

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


}
