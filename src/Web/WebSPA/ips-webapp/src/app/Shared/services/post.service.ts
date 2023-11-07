import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable, catchError, map } from 'rxjs';
import { Postagens } from 'src/app/Core/models/post.models';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PostService extends BaseService {

  constructor(private http: HttpClient) { super ();}

  ListagemPostagens() : Observable<Postagens[]>{
      return this.http
      .get<Postagens[]>(this.UrServiceFeed+"feed",this.ObterAuthHeaderJson() )
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


}
