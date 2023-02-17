import { Component } from '@angular/core';
import { NgxConfigureService } from 'ngx-configure';

@Component({
  selector: 'app-welcome-details',
  templateUrl: './welcome-details.component.html',
  styleUrls: ['./welcome-details.component.scss']
})
export class WelcomeDetailsComponent {
  config: any;

  constructor(public configService: NgxConfigureService) {
    this.config = configService.config;
  }

  // loads when the component is loaded
  ngOnInit() {
  }
}
