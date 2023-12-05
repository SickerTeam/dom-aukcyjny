import {
  ArtworkTitle,
  AuctionDetails,
  AuctionPanel,
  Path,
  PhotoDisplay,
} from "..";

type AuctionPageType = {
  id: string;
};

const AuctionPage = ({ id }: AuctionPageType) => {
  // fetch given auction or pass auction from the auction list page - no need to fetch the same auction again
  

  return (
    <div className="grid grid-cols-4 grid-rows-7 gap-4">
      <div className="col-span-3 row-span-5">
        <Path />
        <ArtworkTitle title={auction.title} />
        <PhotoDisplay photos={auction.photos} />
      </div>
      <div className="row-span-3 col-start-4">
        <AuctionPanel auction={auction} />
      </div>
      <div className="col-span-3 row-span-2 row-start-6 h-full bg-gray-300">
        <AuctionDetails />
      </div>
    </div>
  );
};

export default AuctionPage;
