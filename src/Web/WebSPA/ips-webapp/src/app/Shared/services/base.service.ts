import { HttpErrorResponse, HttpHeaders } from "@angular/common/http"
import { throwError } from "rxjs"
import { LocalStorageUtils } from "src/app/Core/models/localstorage"
import { environment } from "src/environments/environment";
import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
import { getStorage} from 'firebase/storage';

export abstract class BaseService {

    public LocalStorage = new LocalStorageUtils();
    protected UrServiceV1: string = environment.apiUrlAuth
    protected UrServiceFeed: string = environment.apiUrlFeed
    protected UrServiceUsuario: string = environment.apiUrlUsuario
    protected UrServiceHere: string = environment.apiHereGeo
    
    protected app = initializeApp(environment.firebase);
    protected analytics = getAnalytics(this.app);

    protected basePath :string = '/ipsfotos'
    public storage = getStorage();

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
