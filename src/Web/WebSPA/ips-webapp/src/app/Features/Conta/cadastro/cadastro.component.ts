import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { Observable, fromEvent, merge } from 'rxjs';
import { Usuario } from 'src/app/Core/models/usuario.model';
import { DisplayMessage, GenericValidator, ValidationMessages } from 'src/app/Shared/formValidation/generic-form-validation';
import { LoginService } from 'src/app/Shared/services/login.service';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html'
})
export class CadastroComponent implements OnInit, AfterViewInit {


  @ViewChildren(FormControlName,{ read: ElementRef}) formInputElements: ElementRef[];

  errors: any[] = [];
  cadastroForm: FormGroup ;
  usuario : Usuario ;

  valitionMessage : ValidationMessages;
  genericValidator : GenericValidator;
  displayMessage : DisplayMessage = {};
  
  constructor(private fb: FormBuilder, private loginService : LoginService)
  {
  
    this.valitionMessage = {
      UserName: {
        required: 'Informe o Username'
      },
      Celular: {
        required: 'Informe o numero de telefone'
      },
      Nascimento: {
        required: 'Informe a data de nascimento'
      },
      Email: {
        required: 'Informe o email',
        email: 'Email invalido'
      },
      Senha:{
        required: 'Informe a senha'
      },
      SenhaConfirmacao:{
        required: 'Informe a senha novamente',
      }
    };

    this.genericValidator = new GenericValidator(this.valitionMessage);

  }

  ngAfterViewInit(): void
  {
      let controlBlurs: Observable<any>[] = this.formInputElements
      .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

      merge(...controlBlurs).subscribe(() => {
        this.displayMessage = this.genericValidator.processarMensagens(this.cadastroForm)
      });

  }
  
  ngOnInit(): void {

    this.cadastroForm = this.fb.group({
      UserName: ['', [Validators.required]],
      Celular: ['', [Validators.required]],
      Nascimento: ['', [Validators.required]],
      Email: ['', [Validators.required, Validators.email]],
      Senha: ['', [Validators.required]],
      SenhaConfirmacao: ['', [Validators.required]],
    });
  }


   adicionarConta(){
    if (this.cadastroForm.dirty && this.cadastroForm.valid) {
          this.usuario = Object.assign({}, this.usuario, this.cadastroForm.value);
          this.loginService.registrarUsuario(this.usuario);
      }
   }

}
