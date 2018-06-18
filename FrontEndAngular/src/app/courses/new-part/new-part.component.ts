import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-new-part',
  templateUrl: './new-part.component.html',
  styleUrls: ['./new-part.component.css']
})
export class NewPartComponent {
  @Output() shownForm : EventEmitter<void> = new EventEmitter<void>();
  formVisible : boolean = false;

  constructor() { }

  showAndHideForm() : void {
    if (this.formVisible) {
      this.formVisible = false;  
    }  
    else {
      this.formVisible = true;
    }    
  }
}
