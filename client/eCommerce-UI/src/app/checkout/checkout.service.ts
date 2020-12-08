import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IDeliveryMethod } from './../shared/models/deliveryMethod';
import { IOrderToCreate } from './../shared/models/order';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  private apiURL: string = environment.baseURL;

  constructor(private http: HttpClient) { }

  getDeliveryMethods() {
    return this.http.get(this.apiURL + 'order/deliveryMethods').pipe(
      map((dm: IDeliveryMethod[]) => {
        return dm.sort((a, b) => b.price - a.price);
      })
    );
  }

  createOrder(order: IOrderToCreate) {
    return this.http.post(this.apiURL + 'order', order);
  }
}
