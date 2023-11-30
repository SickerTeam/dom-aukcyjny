import { Artworks, Filters, Path } from "..";

const AuctionsListPage = async () => {
  const auctions = Array.from({ length: 100 }, (_, index) => ({
    id: index,
    title: `Mona Lisa by Leonardo da Vinci (1503 - 1506)`,
    price: 1300000, // You can modify this if you want random prices
    time: 10, // You can modify this if you want random times
  }));

  return (
    <div>
      <Path />
      <Filters />

      <Artworks artworks={auctions} />
    </div>
  );
};

export default AuctionsListPage;
