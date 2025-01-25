import React from "react";
import { Title } from "./title";
import { ChecbockFiltersGroup, RangeSlider } from ".";
import { Input } from "../ui";
import { useFilters, useIngredients, useQueryFilter } from "@/hooks";


interface Props {
  className?: string;
}

export const Filters: React.FC<Props> = ({ className }) => {

  const{ingredients, loading} = useIngredients();
  const filters = useFilters();

  useQueryFilter(filters);

  const items = ingredients.map((item) => ({
    value: String(item.ingredientId),
    text: item.name,
  }));

  return (
    <div className={className}>
      <Title text="Filtration" size="sm" className="mb-5 font-bold" />

      <ChecbockFiltersGroup
        name="pizzaTypes"
        className="mb-5"
        title="Type of dough"
        onClickCheckbox={filters.setPizzaTypes}
        selected={filters.pizzaTypes}
        items={[
          { text: "Thin", value: "1" },
          { text: "Traditional", value: "2" },
        ]}
      />

      <ChecbockFiltersGroup
        name="pizzaSizes"
        className="mb-5"
        title="Sizes"
        onClickCheckbox={filters.setPizzaSizes}
        selected={filters.pizzaSizes}
        items={[
          { text: "30sm", value: "30" },
          { text: "40sm", value: "40" },
          { text: "50sm", value: "50" },
        ]}
      />

      <div className="mt-5 border-y border-y-neutral-100 py-6 pb-7">
        <p className="font-bold mb-3">Price from and to:</p>
        <div className="flex gap-3 mb-5">
          <Input
            type="number"
            placeholder="0"
            min={0}
            max={100}
            value={String(filters.prices.priceFrom || 0)}
            onChange={(e) => filters.updatePrice("priceFrom", Number(e.target.value))}
          />
          <Input
            type="number"
            min={10}
            max={100}
            placeholder="100"
            value={String(filters.prices.priceTo || 100)}
            onChange={(e) =>  filters.updatePrice("priceTo", Number(e.target.value))}
          />
        </div>

        <RangeSlider
          min={0}
          max={100}
          step={10}
          value={[filters.prices.priceFrom || 0, filters.prices.priceTo || 100]}
          onValueChange={([from, to]) =>
            filters.setPrices({ priceFrom: from, priceTo: to })
          }
        />

        <ChecbockFiltersGroup
          title={"Ingredients"}
          className="mt-5"
          limit={5}
          items={items}
          defaultItems={items.slice(0, 6)}
          loading={loading}
          onClickCheckbox={filters.setIngredients}
          selected={filters.selectedIngredientsId}
          name="ingredients"
        />
      </div>
    </div>
  );
};
