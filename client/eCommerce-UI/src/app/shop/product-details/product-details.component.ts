import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ShopService } from '../shop.service';
import { IProduct } from './../../shared/models/product';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;

  constructor(private shopService: ShopService, private activatedRouter: ActivatedRoute) { }

  ngOnInit() {
    this.loadProduct();
  }

  loadProduct() {
    this.shopService.getProduct(+this.activatedRouter.snapshot.paramMap.get('id')).subscribe(product => {
      this.product = product;
      console.log(this.product);
    }, error => {
      console.log(error);
    });
  }
}
