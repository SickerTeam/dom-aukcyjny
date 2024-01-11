import { useEffect, useState } from "react";
import PanelButton from "./PanelButton";
import apiService from "../services/apiService";

const BidControll = ({
  auctionId,
  currentPrice,
}: {
  auctionId: number;
  currentPrice: any;
}) => {
  const [suggestedBids, setSuggestedBids] = useState<any>([]);
  const [customBid, setCustomBid] = useState<number | null>(null);
  const [minimumBid, setMinimumBid] = useState<number>(0);

  useEffect(() => {
    createSuggestedBids(currentPrice);
  }, [currentPrice]);

  const createSuggestedBids = (currentPrice: number) => {
    const bracketList = [
      { min: 0, max: 100, bids: [5, 10, 50] },
      { min: 100, max: 1000, bids: [50, 100, 500] },
      { min: 1000, max: 10000, bids: [100, 500, 1000] },
      { min: 10000, max: 100000, bids: [1000, 5000, 10000] },
      { min: 100000, max: 1000000, bids: [10000, 50000, 100000] },
      { min: 1000000, max: 10000000, bids: [100000, 500000, 1000000] },
      { min: 10000000, max: 100000000, bids: [1000000, 5000000, 10000000] },
      { min: 100000000, max: Infinity, bids: [1000000, 5000000, 10000000] },
    ];

    const currentBracket = bracketList.find(
      (bracket) => currentPrice >= bracket.min && currentPrice <= bracket.max
    );

    if (currentBracket) {
      const suggestedBids = currentBracket.bids.map(
        (bid) => currentPrice + bid
      );

      setMinimumBid(suggestedBids[0]);

      setSuggestedBids(suggestedBids.slice(0, 3));
    }

    return null;
  };

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setCustomBid(Number(e.target.value));
  };

  const handleSubmit = () => {
    if (customBid !== null && customBid >= minimumBid) {
      // Perform the API call only if the customBid is not null and greater than the currentPrice
      apiService.post(`/auctions/${auctionId}/bids`, { amount: customBid });
    } else {
      // Handle invalid bid (e.g., show an error message)
      console.error(
        "Invalid bid. Please enter a bid greater than the current price."
      );
    }
  };

  return (
    <div className="bid-controll">
      <div className="suggested-bids flex gap-1">
        {suggestedBids.map((bid: any, index: number) => (
          <PanelButton
            key={index}
            text={`€ ${bid}`}
            onClick={() => setCustomBid(bid)}
          />
        ))}
      </div>
      <div className="my-2">
        <input
          type="text"
          inputMode="numeric"
          pattern="[0-9]+"
          placeholder={`€ 12,600 or up`}
          className="px-4 py-1 border-dark-gray border-2 rounded bg-white"
          value={customBid || ""}
          onChange={handleInputChange}
        />
      </div>
      <button
        className="px-4 py-1 border-dark-gray border-2 rounded bg-white"
        onClick={handleSubmit}
      >
        Place bid
      </button>
    </div>
  );
};

export default BidControll;
