type BidHistoryType = {
  auctionId: string;
};

const BidHistory = ({ auctionId }: BidHistoryType) => {
  // fetch all bids with auctionId
  const history = [
    { name: "Bidder 2137", time: "11h ago", bid: "€ 12,400" },
    { name: "Bidder 8426", time: "23h ago", bid: "€ 12,000" },
    { name: "Bidder 8192", time: "1 day ago", bid: "€ 11,800" },
  ];

  return (
    <div>
      {history.map((bid, index) => (
        <div key={index}>{`${bid.name} | ${bid.time} | ${bid.bid}`}</div>
      ))}
    </div>
  );
};

export default BidHistory;
