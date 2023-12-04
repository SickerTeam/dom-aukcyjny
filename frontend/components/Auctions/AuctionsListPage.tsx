import { Artworks, Filters, Path } from "..";

async function getAllAuctions() {
  const res = await fetch("http://localhost:5156/auction");

  if (!res.ok) {
    throw new Error("Failed to fetch auctions");
  }

  return res.json();
}

const AuctionsListPage = async () => {
  const auctions = await getAllAuctions();
  console.log(auctions);

  return (
    <div>
      <Path />
      <Filters />

      <Artworks artworks={auctions} />
    </div>
  );
};

export default AuctionsListPage;
