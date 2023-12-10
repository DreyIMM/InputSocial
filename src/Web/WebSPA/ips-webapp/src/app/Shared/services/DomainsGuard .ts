import { Injectable, inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";
import { isEmpty } from "rxjs";
import { LocalStorageUtils } from "src/app/Core/models/localstorage";


@Injectable({
    providedIn: 'root'
})
class DomainsGuard{
    private localStorageUtils = new LocalStorageUtils();
    constructor(private router: Router) {}

    canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

        if(!Boolean(this.localStorageUtils.obterTokenUsuario())){
            this.router.navigateByUrl('/')
            return false;
        }

        return true;
    }
    
}

export const AuthGuard: CanActivateFn = (next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean => {
    return inject(DomainsGuard).canActivate(next, state);
}