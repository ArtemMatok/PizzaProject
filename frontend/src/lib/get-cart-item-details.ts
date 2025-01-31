import { mapPizzaType, PizzaSize, PizzaType } from "@/constants/pizza";
import { IngredientGetDto } from "@/models/ingredientModel";

export const getCartItemDetails = (
  pizzaType: PizzaType,
  pizzaSize: PizzaSize,
  ingredients: IngredientGetDto[]
) => {
    const details = [];

    if (pizzaSize && pizzaType) {
      const typeName = mapPizzaType[pizzaType]
      details.push(`${typeName} ${pizzaSize} см`);
    }
  
    if (ingredients) {
      details.push(...ingredients.map((ingredient) => ingredient.name));
    }

    return details.join(', ');
};
