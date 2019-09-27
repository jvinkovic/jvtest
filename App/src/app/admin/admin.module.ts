import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InventoryComponent } from './inventory/inventory.component';
import { RegisterSkiComponent } from './register-ski/register-ski.component';
import { RentSkiComponent } from './rent-ski/rent-ski.component';
import { ReturnSkiComponent } from './return-ski/return-ski.component';
import { MainComponent } from './main/main.component';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

const AdminRoutes: Routes = [
    {
        path: '', component: MainComponent,
        children: [
            { path: 'inventory', component: InventoryComponent },
            { path: 'register', component: RegisterSkiComponent },
            { path: 'rent/:id', component: RentSkiComponent },
            { path: 'return/:id', component: ReturnSkiComponent }
        ]
    }
];

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild(AdminRoutes),
    ],
    declarations: [
        MainComponent,
        InventoryComponent,
        RentSkiComponent,
        ReturnSkiComponent,
        RegisterSkiComponent
    ],
    entryComponents: [
    ]
})

export class AdminModule { }
