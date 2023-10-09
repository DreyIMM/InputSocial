export class Usuario {

    constructor(
        public UserName: string,
        public Celular :string,
        public Nascimento :string,
        public Email: string,
        public Senha: string,
        public SenhaConfirmar: string
    ){}

}

export class UsuarioLogin{

    constructor(
        public Email: string,
        public senha: string,
    ){}

}