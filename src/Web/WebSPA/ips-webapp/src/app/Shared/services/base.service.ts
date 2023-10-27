import { HttpErrorResponse, HttpHeaders } from "@angular/common/http"
import { throwError } from "rxjs"
import { LocalStorageUtils } from "src/app/Core/models/localstorage"
import { environment } from "src/environments/environment";



export abstract class BaseService {

    public LocalStorage = new LocalStorageUtils();
    protected UrServiceV1: string = environment.apiUrlAuth

    protected ObterHeaderJson(){
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
            })
        }
    }

    protected ObterAuthHeaderJson() {
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${this.LocalStorage.obterTokenUsuario()}`
            })
        };
    }

    protected extractData (response : any){
        return response || {}
    }

    protected serviceError(response: Response | any){
        let customError : string [] = [];

        if(response instanceof HttpErrorResponse){
            if(response.statusText === "Unknown Error"){
                customError.push("Ocorreu um erro desconhecido");
                response.error.errors = customError;
            }
        }
        console.log(response);
        return throwError(response);

    }

}