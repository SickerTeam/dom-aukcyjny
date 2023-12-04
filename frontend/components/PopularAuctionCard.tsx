type PopularAuctionCardType = {
  auction: any;
};

const PopularAuctionCard = ({ auction }: PopularAuctionCardType) => {
  return (
    <div className="w-[400px]">
      <div className="h-[200px] bg-light-gray"></div>
      <h3 className="text-xl">{auction.title}</h3>
      <h5 className="uppercase">current bid</h5>
      <h4>{auction.currentBid}</h4>
      <p>{`${auction.daysLeft} days left`}</p>
    </div>
  );
};

export default PopularAuctionCard;
