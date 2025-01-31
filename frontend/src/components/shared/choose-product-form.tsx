import { cn } from "@/lib/utils";
import { IngredientGetDto } from "@/models/ingredientModel";
import { ProductVariantDto } from "@/models/productModel";
import React from "react";
import { Title } from ".";
import { Button } from "../ui";

interface Props {
  className?: string;
  name: string;
  imageUrl: string;
  productVariants: ProductVariantDto[];
  onClickAdd?: () => void;
}

export const ChooseProductForm: React.FC<Props> = ({
  className,
  name,
  imageUrl,
  productVariants,
  onClickAdd,
}) => {
  const textDetails = "30sm, traditional, 590gr ";
  const totalPrice = 12;
  return (
    <div className={cn(className, "flex flex-1")}>
      <div className="flex items-center justify-center flex-1 relative w-full h-full">
        <img
          src={imageUrl}
          alt={name}
          className="relative left-2 top-2 transition-all z-10 duration-300 w-[400px] h-[400px]"
        />
      </div>

      <div className="w-[490px] bg-[#f7f6f5] p-7">
        <Title text={name} size="md" className="font-extrabold mx-1" />

        <p className="text-gray-400">{textDetails}</p>

        <Button className="h-[55px] px-10 text-base rounded-[18px] w-full mt-10">
          Add ${totalPrice}
        </Button>
      </div>
    </div>
  );
};
