import { IngredientGetDto } from "@/models/ingredientModel";

export interface CartItemProps {
    cartItemId: number;
    imageUrl: string;
    details: string;
    name: string;
    price: number;
    quantity: number;
    disabled?: boolean;
  }