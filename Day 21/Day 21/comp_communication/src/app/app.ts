import { Component, signal } from '@angular/core';
import { Parentcomponent } from './parentcomponent/parentcomponent';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Parentcomponent],
  template: `
    <app-parentcomponent></app-parentcomponent>
  `,
  styleUrls: ['./app.css'] // ✅ Correct property name (plural)
})
export class App {
  protected readonly title = signal('comp_communication');
}
