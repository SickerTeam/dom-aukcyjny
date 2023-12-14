import Link from "next/link";

const Navbar = () => {
  return (
    <header className="py-5 mb-8">
      <nav className="flex justify-between items-center">
        <Link href="/">
          <h1 className="text-xl">ZONGERS</h1>
        </Link>
        <div>
          <input
            className="border-[1px] border-light-gray rounded text-center py-1 w-96"
            type="text"
            placeholder="Search by title, artist or category..."
          ></input>
        </div>
        <div className="flex gap-6 text-lg font-semibold">
          <Link href="/auctions">Auctions</Link>
          <Link href="/instabuys">Buy now</Link>
          <Link href="/pricing">Pricing</Link>
          <Link href="/help">Help</Link>
          <Link href="/login">Log in</Link>
        </div>
      </nav>
    </header>
  );
};

export default Navbar;
