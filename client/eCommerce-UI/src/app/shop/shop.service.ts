import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/models/pagination';
import { environment } from './../../environments/environment';
import { IBrand } from './../shared/models/brand';
import { IType } from './../shared/models/productType';
import { map } from 'rxjs/operators';
import { ShopParams } from './../shared/models/shopParams';
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  private apiURL: string = environment.baseURL;

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();
    if (shopParams.brandId !== 0) {
      params = params.append('brandId', shopParams.brandId.toString());
    }
    if (shopParams.typeId !== 0) {
      params = params.append('typeId', shopParams.typeId.toString());
    }
    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    return this.http.get<IPagination>(this.apiURL + 'products', {observe: 'response', params})
    .pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.apiURL + 'products/' + id);
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.apiURL + 'products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.apiURL + 'products/types');
  }
}
