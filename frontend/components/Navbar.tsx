import Link from "next/link";

const Navbar = () => {
  return (
    <header className="w-full py-4">
      <nav className="flex justify-between items-center">
        <Link href="/">
          <h1>ZONGERS</h1>
        </Link>
        <div>
          <input
            className="border-2 border-light-gray rounded text-center py-1 w-96"
            type="text"
            placeholder="Search by title, artist or category..."
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
          <Link href="/log-in">Log in</Link>
        </div>
      </nav>
    </header>
  );
};

export default Navbar;
