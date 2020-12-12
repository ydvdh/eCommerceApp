import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiURL: string = environment.baseURL;

  constructor(private http: HttpClient) { }

  getOrdersForUser() {
    return this.http.get(this.apiURL + 'order');
  }

  getOrderDetailed(id: number) {
    return this.http.get(this.apiURL + 'order/' + id);
  }
}
