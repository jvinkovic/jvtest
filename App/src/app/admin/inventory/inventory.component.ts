import { Component, OnInit } from '@angular/core';
import { SkiService } from 'src/app/services/ski.service';
import { SkiModel } from 'src/app/models/ski.model';

@Component({
  selector: 'app-admin-inventory',
  templateUrl: './inventory.component.html'
})
export class InventoryComponent implements OnInit {

  public skis: SkiModel[];

  constructor(public service: SkiService) { }

  ngOnInit() {
    this.service.getAll().subscribe(r => this.skis = r);
  }

}
