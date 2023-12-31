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
    public imageProfile : string;
}


export class Postagem {

    constructor(
        mensagem: string,
        bairro: string,
        regiao: string,
        latitude: number,
        longitude: number
    ) {
        this.mensagem = mensagem;
        this.bairro = bairro;
        this.regiao = regiao;
        this.latitude = latitude;
        this.longitude = longitude;

    }

    public mensagem: string;
    public bairro: string;
    public regiao: string;
    public latitude: number;
    public longitude: number;
}

export class PostagemDetalhe {

    constructor(
        id: string,
        mensagem: string,
        totalCurtidas: number,
        comentarios: Comentarios[]
    ) {
        this.id = id;
        this.mensagem = mensagem;
        this.totalCurtidas = totalCurtidas
        this.comentarios = comentarios
    }

    public id: string;
    public mensagem: string;
    public totalCurtidas: number;
    public comentarios: Comentarios[];
}

export class Comentarios {
    constructor(){}

    public mensagem:string;
    public nomeUsuarioComentario:string;
}

export class Comentario{
    constructor(
        mensagem: any,
    ){
        this.mensagem = mensagem;
    }

    public mensagem:string;
}
