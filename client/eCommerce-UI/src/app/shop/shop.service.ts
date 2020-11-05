import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { environment } from './../../environments/environment';
import { IBrand } from './../shared/models/brand';
import { IType } from './../shared/models/productType';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  private apiURL: string = environment.baseURL;

  constructor(private http: HttpClient) { }

  getProducts(brandId?: number, typeId?: number) {
    let params = new HttpParams();
    if (brandId) {
      params = params.append('brandId', brandId.toString());
    }
    if (typeId) {
      params = params.append('typeId', typeId.toString());
    }
    return this.http.get<IPagination>(this.apiURL + 'products', {observe: 'response', params})
    .pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.apiURL + 'products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.apiURL + 'products/types');
  }
}
