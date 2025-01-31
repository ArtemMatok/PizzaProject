import { ProductGetDto, ProductWithIngredientsWithPriceDto } from "./productModel";

export interface CategoryWithProductsDto{
    categoryId:number,
    name:string,
    products:ProductGetDto[]
}

export interface CategoryGetDto{
    categoryId:number;
    name:string;
}