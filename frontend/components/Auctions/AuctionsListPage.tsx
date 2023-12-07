import { Artworks, Filters, Path } from "..";

async function getAllAuctions() {
  const res = await fetch("http://localhost:5156/auction");

  if (!res.ok) {
    throw new Error("Failed to fetch auctions");
  }

  return res.json();
}

const AuctionsListPage = async () => {
  //const auctions = await getAllAuctions();
  //console.log(auctions);

  const auctions = [{ id: 1 }, 2, 3, 4, 5, 6, 7, 8, 9, 10];
  return (
    <div className="px-40">
      <Path />
      <Filters />
      <Artworks artworks={auctions} />
    </div>
  );
};

export default AuctionsListPage;
