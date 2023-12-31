import PopularAuctionCard from "./PopularAuctionCard";

const PopularAuctions = () => {
  const popularAuctions = [
    {
      title: "Mona Lisa by Leonardo da Vinci (1503 - 1506)",
      currentBid: "€1,300,000",
      daysLeft: 2,
    },
    {
      title: "Mona Lisa by Leonardo da Vinci (1503 - 1506)",
      currentBid: "€1,300,000",
      daysLeft: 2,
    },
    {
      title: "Mona Lisa by Leonardo da Vinci (1503 - 1506)",
      currentBid: "€1,300,000",
      daysLeft: 2,
    },
    {
      title: "Mona Lisa by Leonardo da Vinci (1503 - 1506)",
      currentBid: "€1,300,000",
      daysLeft: 2,
    },
    {
      title: "Mona Lisa by Leonardo da Vinci (1503 - 1506)",
      currentBid: "€1,300,000",
      daysLeft: 2,
    },
    {
      title: "Mona Lisa by Leonardo da Vinci (1503 - 1506)",
      currentBid: "€1,300,000",
      daysLeft: 2,
    },
  ];

  return (
    <div className="px-40">
      <h3 className="text-xl">Popular auctions</h3>
      <div className="flex gap-6">
        {popularAuctions.map((auction, index) => (
          <PopularAuctionCard key={index} auction={auction} />
        ))}
      </div>
    </div>
  );
};

export default PopularAuctions;
