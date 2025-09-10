import { Component } from '@angular/core';

import { Childcomponent } from '../childcomponent/childcomponent';

@Component({
  selector: 'app-parentcomponent',
  standalone: true,
  imports: [Childcomponent],
  templateUrl: './parentcomponent.html',
  styleUrl: './parentcomponent.css'
})
export class Parentcomponent {
  parentMessage: string = "Hello Child! Message from Parent.";
  messageFromChild: string = '';

  receiveMessage($event: string) {
   this.messageFromChild = $event;
  }

}