type GUID = string & { isGuid: true};
function guid(guid: string) : GUID {
    return  guid as GUID; 
}

export class Postagens{
 
    constructor(){}

    public nomeUsuario:string;
    public id: GUID;
    public idUsuario: GUID;
    public dataPostagem: Date;
    public modificado: Boolean;
    public mensagem: string;
    public totalCurtidas: number;
    public bairro : string;
    public regiao : string;
}