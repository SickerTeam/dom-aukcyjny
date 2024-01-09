// add column to the auciton table which is updated when new bid is placed - it would store current bid id
// create custom classes to reduce classnames spam in divs

import CountdownTimer from "../CountdownTimer";
import BidHistory from "./BidHistory";

type AuctionPanelType = {
  auction: any;
};

const AuctionPanel = ({ auction }: AuctionPanelType) => {
  return (
    <div>
      <CountdownTimer endsAt={auction.endsAt} />
      <div className="panel-container bg-light-gray p-2 ">
        <div className="panel-price-container my-2">
          <p className="current-bid uppercase">current bid</p>
          <h2>€ 12,400</h2>
          <h4>Reserve price met</h4>
        </div>
        <div className="panel-owner-container flex gap-2 my-2">
          <div className="w-[100px] h-[100px] bg-gray-500 rounded-full"></div>
          <div className="owner-texts">
            <h3 className="owner-estimate">Estimate € 12,000 - € 14,000</h3>
            <p className="go-to-owner-profile">Go to "X" profile</p>
          </div>
          <div className="info-icon">
            <p>i</p>
          </div>
        </div>
        <div className="panel-bid-container my-2">
          <div className="suggested-bids flex gap-2">
            <button className="border border-black rounded bg-white">
              € 12,600
            </button>
            <button className="border border-black rounded bg-white">
              € 12,800
            </button>
            <button className="border border-black rounded bg-white">
              € 13,000
            </button>
          </div>
          <input
            type="text"
            inputMode="numeric"
            pattern="[0-9]+"
            placeholder={`€ 12,600 or up`}
            className="border border-black rounded my-2"
            // min={currentPrice + minimumBidForThisPriceBracket}
          />
          <div className="flex gap-2">
            {/* change divs to buttons i guess */}
            <button className="border border-black rounded bg-white">
              Place bid
            </button>
            <button className="border border-black rounded bg-white">
              Set max bid
            </button>
          </div>
        </div>
        <div className="panel-info-container my-2">
          <p>Buyer protection</p>
          <p>Shipping from & when</p>
          <p>Buyer protection fee</p>
          <p>Biding closes on ...</p>
        </div>
        <BidHistory auctionId={auction.id} />
      </div>
    </div>
  );
};

export default AuctionPanel;
