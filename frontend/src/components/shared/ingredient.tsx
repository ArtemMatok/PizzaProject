import { cn } from "@/lib/utils";
import { IngredientGetDto } from "@/models/ingredientModel";
import { CircleCheck } from "lucide-react";
import React from "react";

interface Props {
  className?: string;
  ingredient: IngredientGetDto;
  active?: boolean;
  onClick?: () => void;
}

export const Ingredient: React.FC<Props> = ({
  className,
  ingredient,
  active,
  onClick,
}) => {
  return (
    <div
      className={cn(
        "flex items-center flex-col p-1 rounded-md w-32 text-center relative cursor-pointer shadow-md bg-white",
        {"border border-primary" : active},
        className
      )}
      onClick={onClick}
    >
      {active && <CircleCheck className="absolute top-2 right-2 text-primary"/>}
      <img src={ingredient.imageUrl} alt={ingredient.name} width={110} height={110}/>
      <span className="text-xs mb-1">{ingredient.name}</span>
      <span className="font-bold">${ingredient.price}</span>
    </div>
  );
};
