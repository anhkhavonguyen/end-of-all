import { Component, AfterViewInit } from '@angular/core';
@Component({
  templateUrl: './starter.component.html'
})
export class StarterComponent {
  subtitle: string;
  constructor() {
    this.subtitle = 'Hi All! I am Kha';
  }
}
