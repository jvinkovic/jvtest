import { BaseModel } from './base.model';

export interface RentModelBase extends BaseModel {
    customerName: string;
    skiId: number;
}

export interface RentModel extends RentModelBase {
    rentedAt: string;
    returnedAt?: string;
    hourlyRate: number;
}