import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { environment } from './../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  private apiURL: string = environment.baseURL;

  constructor(private http: HttpClient) { }

  getProducts() {
    return this.http.get<IPagination>(this.apiURL + 'products?pageSize=50');
  }
}
