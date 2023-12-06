import Link from "next/link";

const Navbar = () => {
  return (
    <header className="w-full py-2">
      <nav className="flex justify-between items-center">
        <Link href="/">
          <h1>ZONGERS</h1>
        </Link>
        <div>
          <input
            className="w-96 h-8 border-2 border-black rounded-full text-center ml-28"
            type="text"
            placeholder="Search by title,artist or category..."
          ></input>
        </div>
        <div className="flex">
          <Link href="/sell" className="pr-4">
            Sell
          </Link>
          <Link href="/pricing" className="pr-4">
            Pricing
          </Link>
          <Link href="/help" className="pr-4">
            Help
          </Link>
          <Link href="/login">Log in</Link>
        </div>
      </nav>
    </header>
  );
};

export default Navbar;
