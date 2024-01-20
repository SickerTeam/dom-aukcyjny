import Image from "next/image";
import timeAgoCalculator from "../services/timerAgoCalculator";
type ArtworkCardType = {
  artwork: any;
};

const ArtworkCard = ({ artwork }: ArtworkCardType) => {
  let imgSrc = '';
  if (artwork.product.productImages && artwork.product.productImages.length > 0) {
   imgSrc = artwork.product.productImages[0].link;
  }
  return (
    <a href={`/auctions/${artwork.id}`}>
      <div className="cursor-pointer">
        <Image
          src={imgSrc}
          alt="Zong logo"
          className="object-fill h-300 w-350 rounded-md drop-shadow-md "
          width={300}
          height={350}
        />  
        <h1 className="w-full text-black text-2xl font-semibold font-['Playfair Display']">
          {artwork.product.title}
        </h1>
        <div className="text-neutral-500 text-base font-normal font-['Source Sans Pro']">
          CURRENT BID
        </div>
        <h2 className="text-neutral-900 text-2xl font-semibold font-['Source Sans Pro']">
          €{artwork.startingPrice}
        </h2>
        <p className="text-neutral-500 text-base font-semibold font-['Source Sans Pro']">
          {timeAgoCalculator.calculateTimeReamaning(artwork.endsAt)} 
        </p>
      </div>
    </a>
  );
};
export default ArtworkCard;
