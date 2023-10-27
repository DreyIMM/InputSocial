export class LocalStorageUtils {
    
    public obterUsuario() {
        return JSON.parse(localStorage.getItem('ips.user') || '{}');
    }

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

    public salvarTokenUsuario(token: string) {
        localStorage.setItem('ips.token', token);
    }

    public salvarUsuarioClaims(user: string) {
        localStorage.setItem('ips.user', JSON.stringify(user));
    }

}