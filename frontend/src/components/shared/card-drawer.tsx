import React from "react";

import {
  Sheet,
  SheetClose,
  SheetContent,
  SheetFooter,
  SheetHeader,
  SheetTitle,
  SheetTrigger,
} from "@/components/ui/sheet";
import { Link } from "react-router-dom";
import { Button } from "../ui";
import { ArrowRight } from "lucide-react";
import { CardDrawerItem } from ".";

interface Props {
  className?: string;
}

export const CardDrawer: React.FC<React.PropsWithChildren<Props>> = ({
  children,
  className,
}) => {
  return (
    <Sheet>
      <SheetTrigger asChild>{children}</SheetTrigger>
      <SheetContent className="flex flex-col justify-between pb-0 bg-[#F4F1EE]">
        <SheetHeader>
          <SheetTitle>
            In basket: <span className="font-bold">3 items</span>
          </SheetTitle>
        </SheetHeader>

        <div className="-mx-6 mt-5 overflow-auto scrollbar flex-1">
          <div className='mb-2'>
            <CardDrawerItem
              cartItemId={0}
              imageUrl={
                "data:image/jpeg;base64,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"
              }
              details={""}
              name={"фывфывфв"}
              price={10}
              quantity={1}
            />
          </div>

        </div>

        <SheetFooter className="-mx-6 bg-white p-8">
          <div className="w-full">
            <div className="flex mb-4">
              <span className="flex flex-1 text-lg text-neutral-500">
                Sum:
                <div className="fkex-1 border-b border-dashed border-b-neutral-200 relative -top-1 mx-2" />
              </span>

              <span className="font-bold text-lg">$12</span>
            </div>

            <Link to="/cart">
              <Button type="submit" className="w-full h-12 text-base">
                Checkout
                <ArrowRight className="w-5 ml-5" />
              </Button>
            </Link>
          </div>
        </SheetFooter>
      </SheetContent>
    </Sheet>
  );
};
