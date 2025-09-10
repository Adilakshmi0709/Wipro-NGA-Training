import { Component, signal,OnInit, OnChanges, SimpleChanges } from '@angular/core';
@Component({
  selector: 'app-root',
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnChanges {
    title = 'onchanges';
    data: string = 'Initial Data';
    ngOnChanges(changes:SimpleChanges): void
     {
        if (changes ['data']) {
            console.log('Previous:', changes['data'].previousValue);
            console.log('Current:', changes['data'].currentValue);
        }
    }
    changeData() {
        this.data = 'Updated Data';
    }
}