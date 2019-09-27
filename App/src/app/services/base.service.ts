import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

const BASE = environment.API;

@Injectable({
    providedIn: 'root'
})
export class BaseService<T> {
    public controller: string;

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json'
        })
    };

    constructor(controller: string, protected httpClient: HttpClient) {
        this.controller = controller;
    }

    public getAll(): Observable<T[]> {
        return this.httpClient.get<T[]>(BASE + '/' + this.controller);
    }

    public get(id: number): Observable<T> {
        return this.httpClient.get<T>(BASE + '/' + this.controller + '/' + id.toString());
    }

    public create(model: T): Observable<any> {
        return this.httpClient.post<any>(BASE + '/' + this.controller, model, this.httpOptions);
    }

    public edit(id: number, model: T): Observable<Number> {
        return this.httpClient.put<Number>(BASE + '/' + this.controller + '/' + id.toString(), model, this.httpOptions);
    }
}
