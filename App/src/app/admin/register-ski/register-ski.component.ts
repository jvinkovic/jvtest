import { Component } from '@angular/core';
import { SkiModel } from 'src/app/models/ski.model';
import { SkiService } from 'src/app/services/ski.service';

@Component({
  selector: 'app-admin-register-ski',
  templateUrl: './register-ski.component.html'
})
export class RegisterSkiComponent {

  ski = new SkiModel();

  constructor(public service: SkiService) {
  }

  save() {
    this.service.create(this.ski).subscribe(r => alert(r)); console.log(this.ski);
  }
}
