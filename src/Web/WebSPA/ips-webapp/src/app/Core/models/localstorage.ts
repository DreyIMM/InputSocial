export class LocalStorageUtils {
    

    public salvarDadosLocaisUsuario(response: any) {
        this.salvarTokenUsuario(response.accessToken);
        this.salvarUsuarioClaims(response.usuarioToken);
    }

    public limparDadosLocaisUsuario() {
        localStorage.removeItem('ips.token');
        localStorage.removeItem('ips.user');
    }

    public obterTokenUsuario(): string {
        return localStorage.getItem('ips.token') || '';
    }

    public obterUsuario() {
        return JSON.parse(localStorage.getItem('ips.user') || '{}');
    }

    public obterNome(){
        return JSON.parse(localStorage.getItem('ips.usuario') || '');
    }

    public salvarTokenUsuario(token: string) {
        localStorage.setItem('ips.token', token);
    }

    public salvarUsuarioClaims(user: string) {
        localStorage.setItem('ips.user', JSON.stringify(user));
    }

    public salvaNomeUsuaio(user : any){
        localStorage.setItem('ips.usuario', JSON.stringify(user.content))
    }
}