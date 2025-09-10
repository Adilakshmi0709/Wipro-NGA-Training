import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Parentcomponent } from '../parentcomponent/parentcomponent';

@Component({
  selector: 'app-childcomponent',
  standalone:true,
  imports: [],
  templateUrl: './childcomponent.html',
  styleUrl: './childcomponent.css'
})
export class Childcomponent {
  // Receive data from parent
  @Input() childMessage: string = '';

  // Send data to parent
  @Output() messageEvent = new EventEmitter<string>()

  sendMessageToParent() {
  this.messageEvent.emit("Hello Parent! Message from Child.");
  }

}