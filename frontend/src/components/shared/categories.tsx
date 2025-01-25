import { cn } from "@/lib/utils";
import { useCategoryStore } from "@/store/category";
import React from "react";

interface Props {
  className?: string;
}

const categories = [
  { id: 1, name: "Pizza" },
  { id: 2, name: "Breakfast" },
  { id: 3, name: "Cocteils" },
  { id: 4, name: "Coffee" },
  { id: 5, name: "Desert" },
  { id: 6, name: "Drinks" },
];

export const Categories: React.FC<Props> = ({ className }) => {
  const categoryActiveId = useCategoryStore((state) => state.activeId);
  return (
    <div
      className={cn("inline-flex gap-1 bg-grey-50 p-1 rounded-2xl", className)}
    >
      {categories.map((cat, index) => (
        <a
          className={cn(
            "flex items-center font-bold h-11 rounded-2xl px-5",
            categoryActiveId ===cat.id &&
              "bg-white shadow-md shadow-gray-200 text-primary"
          )}
          href={`/#${cat.name}`}
          key={index}
        >
          <button>{cat.name}</button>
        </a>
      ))}
    </div>
  );
};
