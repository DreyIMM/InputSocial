import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { DisplayMessage, GenericValidator, ValidationMessages } from 'src/app/Shared/formValidation/generic-form-validation';

@Component({
  selector: 'app-root',
  templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  
  loginForm: FormGroup ;
  errors: any[] = [];

  valitionMessage : ValidationMessages;
  genericValidator : GenericValidator;
  displayMessage : DisplayMessage = {};
  
  ngOnInit(): void {
   
  }

  LogarConta(){

  }

}
