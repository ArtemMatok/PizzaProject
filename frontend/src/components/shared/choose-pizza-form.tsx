import { cn } from "@/lib/utils";
import { IngredientGetDto } from "@/models/ingredientModel";
import { ProductVariantDto } from "@/models/productModel";
import React from "react";
import { Ingredient, PizzaImage, ProductSelector, Title } from ".";
import { Button } from "../ui";
import {
  mapPizzaType,
  PizzaSize,
  PizzaType,
} from "@/constants/pizza";
import { usePizzaConfiguration } from "@/hooks/usePizzaConfiguration";
import { useIngredients } from "@/hooks/useIngredients";
import { usePizzaPricing } from "@/hooks/usePizzaPricing";

interface Props {
  className?: string;
  name: string;
  imageUrl: string;
  ingredients: IngredientGetDto[];
  productVariants: ProductVariantDto[];
  pizzaSize: PizzaSize;
  pizzaType: PizzaType;
  onClickAddCart?: () => void;
  productId: number;
}

export const ChoosePizzaForm: React.FC<Props> = ({
  className,
  name,
  imageUrl,
  ingredients,
  productVariants,
  pizzaSize,
  pizzaType,
  onClickAddCart,
  productId,
}) => {
  const {
    size,
    type,
    setSize,
    setType,
    availableSizes,
    availableTypes,
  } = usePizzaConfiguration(pizzaSize, pizzaType, productVariants);

  const {
    activeIngredients,
    handleIngredientClick,
  } = useIngredients(ingredients);

  const { totalPrice } = usePizzaPricing(
    productVariants,
    ingredients,
    size,
    type,
    activeIngredients
  );

  const textDetails = `${size}sm, ${
    mapPizzaType[type!]
  }, ingredients:${ingredients.map((ing) => ing.name).join(", ")}`;

  const handleClickAddCart = () => {
    onClickAddCart?.();
  };

  return (
    <div className={cn(className, "flex flex-1")}>
      <PizzaImage imageUrl={imageUrl} size={size as PizzaSize} />

      <div className="w-[490px] bg-[#f7f6f5] p-7">
        <Title text={name} size="md" className="font-extrabold mx-1" />

        <p className="text-gray-400">{textDetails}</p>

        <div className="flex flex-col gap-5 my-5">
          <ProductSelector
            items={availableSizes}
            selectedValue={String(size)}
            onClick={(value) => setSize(Number(value) as PizzaSize)}
          />

          <ProductSelector
            items={availableTypes}
            selectedValue={String(type)}
            onClick={(value) => setType(Number(value) as PizzaType)}
          />
        </div>

        <div className="bg-gray-50 p-5 rounded-md h-[420px] overflow-auto scrollbar mt-5">
          <div className="grid grid-cols-3 gap-3">
            {ingredients.map((ingredient) => (
              <Ingredient
                ingredient={ingredient}
                key={ingredient.ingredientId}
                active={activeIngredients.includes(ingredient.ingredientId)}
                onClick={() => handleIngredientClick(ingredient.ingredientId)}
              />
            ))}
          </div>
        </div>

        <div className="flex gap-3 mt-10">
          <Button
            onClick={handleClickAddCart}
            className="h-[55px] px-10 text-base rounded-[18px] flex-1"
          >
            Add ${totalPrice}
          </Button>

          <Button
            variant="outline"
            onClick={() => (window.location.href = `/product/${productId}`)}
            className="h-[55px] px-6 text-base rounded-[18px]"
          >
            View Details
          </Button>
        </div>
      </div>
    </div>
  );
};
