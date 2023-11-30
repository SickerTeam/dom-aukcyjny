import { Artworks, Filters, Path } from "..";

async function getAllAuctions() {
  const res = await fetch("http://localhost:7141/auctions");

  if (!res.ok) {
    throw new Error("Failed to fetch auctions");
  }

  return res.json();
}

const AuctionsListPage = async () => {
  // const artworks = Array.from({ length: 100 }, (_, index) => ({
  //   id: index,
  //   title: `Mona Lisa by Leonardo da Vinci (1503 - 1506)`,
  //   price: 1300000, // You can modify this if you want random prices
  //   time: 10, // You can modify this if you want random times
  // }));

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
