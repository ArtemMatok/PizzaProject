import { useSearchParams } from "react-router";
import { useState } from "react";
import { useSet } from "react-use";

interface PriceProps {
  priceFrom?: number;
  priceTo?: number;
}
export interface Filters{
  pizzaSizes:Set<string>;
  pizzaTypes:Set<string>;
  selectedIngredientsId: Set<string>;
  prices: PriceProps;
}

export const useFilters = () => {
  const [searchParams] = useSearchParams();

  const [prices, setPrices] = useState<PriceProps>({
    priceFrom: Number(searchParams.get("priceFrom")) || undefined,
    priceTo: Number(searchParams.get("priceTo")) || undefined,
  });

  const [pizzaSizes, { toggle: togglePizzaSizes }] = useSet(
    new Set<string>(
      searchParams.has("pizzaSizes") ? searchParams.get("pizzaSizes")?.split(",") : []
    )
  );

  const [pizzaTypes, { toggle: togglePizzaTypes }] = useSet(
    new Set<string>(
      searchParams.has("pizzaTypes") ? searchParams.get("pizzaTypes")?.split(",") : []
    )
  );

  const [selectedIngredientsId, { toggle: toggleSelectedIngredients }] = useSet(
    new Set<string>(
      searchParams.has("ingredients") ? searchParams.get("ingredients")?.split(",") : []
    )
  );

  const updatePrice = (name: keyof PriceProps, value: number) => {
    setPrices({
      ...prices,
      [name]: value,
    });
  };


  return {
    pizzaSizes,
    pizzaTypes,
    selectedIngredientsId,
    prices,
    updatePrice: updatePrice,
    setPrices,
    setPizzaTypes: togglePizzaTypes,
    setPizzaSizes: togglePizzaSizes,
    setIngredients: toggleSelectedIngredients,
  };
};
