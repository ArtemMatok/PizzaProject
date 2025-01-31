import { cn } from "@/lib/utils";
import React from "react";
import { Button } from "../ui";
import { CardButton, Container, SearchInput } from ".";
import { ArrowRight, ShoppingCart, User } from "lucide-react";
import { Link } from "react-router-dom";

interface Props {
  className?: string;
}

export const Header: React.FC<Props> = ({ className }) => {
  return (
    <header className={cn("border border-b", className)}>
      <Container className="flex items-center justify-between py-8 ">
        {/* Left side */}
        <Link to={"/"}>
          <div>
            <img width={35} height={35} src="/logo.png" />
            <div>
              <h1 className="text-2xl uppercase font-black">Pizzonix</h1>
              <p className="text-sm text-grey-400 leading-3">yummy</p>
            </div>
          </div>
        </Link>

        <div className="mx-10 flex-1">
            <SearchInput />
        </div>

        {/* Right side */}
        <div className="flex items-center gap-3">
          <Button variant="outline" className="flex items-center gap-1">
            <User size={16} />
            Sign in
          </Button>

          <div>
            <CardButton />
          </div>
        </div>
      </Container>
    </header>
  );
};
