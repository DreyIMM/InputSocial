import { HttpErrorResponse, HttpHeaders } from "@angular/common/http"
import { throwError } from "rxjs"
import { LocalStorageUtils } from "src/app/Core/models/localstorage"



export abstract class BaseService {

    public LocalStorage = new LocalStorageUtils();
    protected UrServiceV1: string = 'https://localhost:44378/api/identidade/'

    protected ObterHeaderJson(){
        return {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
            })
        }
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