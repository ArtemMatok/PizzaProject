import { CartItemGetDto } from "./cartItemModel";

export interface CartGetDto{
    tokenCart: string,
    totalAmount: number,
    cartItems: CartItemGetDto[]
}