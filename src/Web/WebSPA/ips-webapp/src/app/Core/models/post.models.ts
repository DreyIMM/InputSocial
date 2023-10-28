type GUID = string & { isGuid: true};
function guid(guid: string) : GUID {
    return  guid as GUID; 
}

export class Postagens{
 
    constructor(){}

    public Id: GUID;
    public IdUsuario: GUID;
    public DataPostagem: Date;
    public Modificado: Boolean;
    public Mensagem: string;
    public TotalCurtidas: number;

}