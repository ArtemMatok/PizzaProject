import { IngredientBasicDto } from "@/models/ingredientModel";
import { Api } from "@/services/api-client";
import { useEffect, useState } from "react";

export const useIngredients = () => {
  const [ingredients, setIngredients] = useState<IngredientBasicDto[]>([]);
  const[loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    setLoading(true);
    Api.ingredients
      .getIngredientsBasic()
      .then((items) => {
        setIngredients(items || []);
      })
      .catch((e) => console.log(e))
      .finally(() => setLoading(false));
  }, []);

  return {
    ingredients,
    loading
  }
};
