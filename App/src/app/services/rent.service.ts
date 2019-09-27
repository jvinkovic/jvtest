import { BaseService } from './base.service';
import { Injectable, Inject } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { RentModel, RentModelBase } from '../models/rent.model';
import { HttpClient } from '@angular/common/http';

const BASE = environment.API;

@Injectable({
    providedIn: 'root'
})
export class RentService extends BaseService<RentModel> {
    constructor(@Inject(HttpClient) http) {
        super('Rent', http);
    }

    public create(model: RentModelBase): Observable<any> {
        return this.httpClient.post<any>(BASE + '/' + this.controller, model, this.httpOptions);
    }

    public return(id: number): Observable<Number> {
        return this.httpClient.post<Number>(BASE + '/' + this.controller + '/' + id.toString(), this.httpOptions);
    }
}
