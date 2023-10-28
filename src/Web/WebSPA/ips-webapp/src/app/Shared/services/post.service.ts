import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { Observable, catchError } from 'rxjs';
import { Postagens } from 'src/app/Core/models/post.models';
import { HttpClient } from '@angular/common/http';

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


}
