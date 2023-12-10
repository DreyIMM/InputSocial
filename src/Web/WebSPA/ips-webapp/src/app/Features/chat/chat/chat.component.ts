import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Usuario, Usuarios } from 'src/app/Core/models/usuario.model';
import { ChatService } from 'src/app/Shared/services/chat.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {

  public usuarios: Usuarios[] = [new Usuarios()];

    searchControl = new FormControl
    constructor(
      private chatservice: ChatService,
    ){ 
        this.todoUsuarios();
     }

    //Pesquisar de como fazer o auto-complete
    todoUsuarios(){
        this.chatservice.todoUsuarios().subscribe((data: any) => {
          this.usuarios = data
        });    
    }
       
}
