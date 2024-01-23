import timerAgoCalculator from '../services/timerAgoCalculator';
type PopularAuctionCardType = {
  auction: any;
};



const PopularAuctionCard = ({ auction }: PopularAuctionCardType) => {
  let imgSrc = '../public/cv2.png';
if (auction.product.productImages && auction.product.productImages.length > 0) {
 imgSrc = auction.product.productImages[0].link;
}
  
  return (
    <div className="w-[400px]">
      <div className="h-[200px] bg-light-gray rounded">
        <img src= {imgSrc} alt="" className="w-full h-full object-cover rounded" />
      </div>
      <h3 className="text-xl">{auction.product.title}</h3>
      <h5 className="uppercase">current bid:</h5>
      <h4>{auction.estimateMinPrice} dkk</h4>
      <p>{timerAgoCalculator.calculateTimeReamaning(auction.endsAt)}</p>
    </div>
  );
};

export default PopularAuctionCard;
