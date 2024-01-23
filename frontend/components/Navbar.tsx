"use client";

import {
  Button,
  Dropdown,
  DropdownItem,
  DropdownMenu,
  DropdownTrigger,
} from "@nextui-org/react";
import Link from "next/link";

const Navbar = () => {
  return (
    <header className="py-5 mb-8">
      <nav className="flex justify-between items-center">
        <Link href="/">
          <p className="text-2xl font-bold tracking-wide">
            Bid<span className="text-main-green">Hub</span>
          </p>
        </Link>
        <input
          className="border-b border-light-gray text-center py-1 px-8"
          type="text"
          placeholder="Search by title or artist..."
        ></input>
        <div className="flex gap-6 text-xl">
          <Link href="/lots">Sell</Link>
          <div>
            <Dropdown>
              <DropdownTrigger>
                <Button variant="bordered">Artworks</Button>
              </DropdownTrigger>
              <DropdownMenu aria-label="Link Actions">
                <DropdownItem key="auctions" href="/auctions">
                  Auctions
                </DropdownItem>
                <DropdownItem key="buy-now" href="/buy-now">
                  Buy now
                </DropdownItem>
              </DropdownMenu>
            </Dropdown>
          </div>
          <Link href="/posts">Posts</Link>
          <Link href="/pricing">Pricing</Link>
          <Link href="/help">Help</Link>
          <Link href="/login">Log in</Link>
        </div>
      </nav>
    </header>
  );
};

export default Navbar;
