import { BaseService } from './base.service';
import { Injectable, Inject } from '@angular/core';
import { SkiModel } from '../models/ski.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class SkiService extends BaseService<SkiModel> {
    constructor(@Inject(HttpClient) http) {
        super('Ski', http);
    }
}
