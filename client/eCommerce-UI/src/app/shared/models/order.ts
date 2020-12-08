import { IAddress } from './Address';

export interface IOrderToCreate {
    basketId: string;
    deliveryMethodId: number;
    shipToAddress: IAddress;
}

export interface IOrder {
    id: number;
    buyerEmail: string;
    orderDate: string;
    shipToAddress: IAddress;
    deliveryMethod: string;
    shippingPrice: number;
    orderItems: IOrderItem[];
    subTotal: number;
    total: number;
    status: number;
}

export interface IOrderItem {
    id: number;
    productName: string;
    pictureUrl: string;
    price: number;
    quantity: number;
}
