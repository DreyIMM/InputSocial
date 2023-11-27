export class Usuario {

    constructor(
    ){}

    
    public userName: string;
    public celular :string;
    public nascimento :string;
    public email: string;
    public senha: string;
    public senhaConfirmacao: string;

}

export class UsuarioLogin{
    constructor(){}

    public Email: string;
    public Senha: string;
    

}


export class UsuarioRespostaLogin{
    constructor(
        public AcessToken : string,
        public ExpiresIn  : number,
        public UsuarioToken : UsuarioToken
    ){}
}

export class UsuarioToken{
    constructor(
        public Id : string,
        public Email : string,
        public Claims: Array<UsuarioClaim> = []
    ){}
}

export class UsuarioClaim{
    constructor(
        public Value: string,
        public Type : string,
    ){}
}
