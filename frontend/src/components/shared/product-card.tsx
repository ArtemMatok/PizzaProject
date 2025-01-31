import React from "react";
import { Title } from ".";
import { Button } from "../ui";
import { Plus } from "lucide-react";

interface Props {
  productId: number;
  name: string;
  imageUrl: string;
  className?: string;
  ingredients:string[];
  price: number;
  onClick?: () => void;
}

export const ProductCard: React.FC<Props> = ({
  productId,
  name,
  imageUrl,
  price,
  ingredients,
  onClick,
  className,
}) => {
  return (
    <div className={className} onClick={onClick}>
      <div className="flex justify-center p-6 bg-secondary rounded-lg h-[260px]">
        <img src={imageUrl} alt={name} className="w-[215px] h-[215px]" />
      </div>

      <Title text={name} size="sm" className="mb-1 mt-3 font-bold" />

      <p className="text-sm text-gray-400">{ingredients.join(", ")}</p>

      <div className="flex justify-between items-center mt-4">
        <span className="text-[20px]">
          from <b>${price}</b>
        </span>

        <Button variant={"secondary"} className="text-base font-bold">
          <Plus size={20} className="w-5 h-5 mr-1" />
          Add
        </Button>
      </div>
    </div>
  );
};
