import BuyNowControll from "./BuyNowControll";

const BuyNowPanel = ({ buyNow }) => {
  return (
    <div className="panel-container bg-light-gray rounded-lg p-4">
      <div className="panel-price-container mb-4">
        <p className="current-bid uppercase font-bold">Buy it now price</p>
        <h2 className="text-4xl">€ {buyNow.price}</h2>
      </div>
      <div className="panel-owner-container flex gap-4 my-4 items-center">
        <div className="w-[100px] h-[100px] bg-white rounded-full"></div>
        <p className="go-to-owner-profile">Go to owner profile</p>
      </div>
      <div className="my-4">
        <BuyNowControll buyNowId={buyNow.id} price={buyNow.price} />
      </div>
      <div className="panel-info-container mt-4">
        <p>Buyer protection</p>
        <p>Shipping information</p>
        <p>Buyer protection fee</p>
      </div>
    </div>
  );
};

export default BuyNowPanel;
