import { PizzaSize, PizzaType } from "@/constants/pizza";
import { IngredientGetDto } from "@/models/ingredientModel";
import { ProductVariantDto } from "@/models/productModel";

export const usePizzaPricing = (
  productVariants: ProductVariantDto[],
  ingredients: IngredientGetDto[],
  size: PizzaSize,
  type: PizzaType,
  activeIngredients: number[]
) => {
  const pizzaPrice = productVariants.find(
    (variant) => variant.pizzaType === type && variant.size === size
  )?.price;

  const totalIngredientsPrice = activeIngredients.reduce(
    (acc, ingredientId) => {
      const ingredient = ingredients.find(
        (ing) => ing.ingredientId === ingredientId
      );
      return acc + (ingredient?.price || 0);
    },
    0
  );

  const totalPrice = Math.round((pizzaPrice! + totalIngredientsPrice) * 100) / 100;

  return {
    pizzaPrice,
    totalIngredientsPrice,
    totalPrice,
  };
}; 