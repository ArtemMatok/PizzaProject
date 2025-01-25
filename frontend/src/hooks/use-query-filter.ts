import qs from "qs";
import { useEffect} from "react";
import { useNavigate } from "react-router";
import { Filters } from "./use-filters";

export const useQueryFilter = (filters: Filters) => {
  const navigate = useNavigate();

  useEffect(() => {
    const params = {
      ...filters.prices,
      pizzaTypes: Array.from(filters.pizzaTypes),
      sizes: Array.from(filters.pizzaSizes),
      ingredients: Array.from(filters.selectedIngredientsId),
    };
    const query = qs.stringify(params, { arrayFormat: "comma" });
    navigate(`?${query}`, { replace: true });
    console.log(query);
  }, [filters.prices,filters.pizzaTypes,filters.pizzaSizes,filters.selectedIngredientsId]);

};
