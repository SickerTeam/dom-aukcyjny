import { Artworks, Filters, Path } from "..";

async function getAllAuctions() {
  const res = await fetch("https://sea-turtle-app-yvb56.ondigitalocean.app/auction");

  if (!res.ok) {
    throw new Error("Failed to fetch auctions");
  }

  return res.json();
}

const AuctionsListPage = async () => {
  const auctions = await getAllAuctions();


  return (
    <div>
      <Path />
      <Filters />

      <Artworks artworks={auctions} />
    </div>
  );
};

export default AuctionsListPage;
