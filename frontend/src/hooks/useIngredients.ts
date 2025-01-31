import { IngredientGetDto } from "@/models/ingredientModel";
import { useState } from "react";

export const useIngredients = (ingredients: IngredientGetDto[]) => {
  const [activeIngredients, setActiveIngredients] = useState<number[]>([]);

  const handleIngredientClick = (ingredientId: number) => {
    setActiveIngredients((prev) =>
      prev.includes(ingredientId)
        ? prev.filter((id) => id !== ingredientId)
        : [...prev, ingredientId]
    );
  };

  return {
    activeIngredients,
    handleIngredientClick,
  };
}; 