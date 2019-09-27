import { BaseModel } from './base.model';

export class SkiModel implements BaseModel {
    id: number;
    name: string;
    hourlyRate: number;
    rented: boolean;
}
