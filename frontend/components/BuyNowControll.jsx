const BuyNowControll = ({ buyNowId, price }) => {
  return (
    <div className="flex gap-2">
      <button
        className="px-4 py-1 shadow-sm rounded text-white bg-main-green"
        onClick={() => console.log("buy now")}
      >
        Buy now
      </button>
      <button
        className="px-4 py-1 rounded bg-white shadow-sm"
        onClick={() => console.log("Make offer")}
      >
        Make offer
      </button>
    </div>
  );
};

export default BuyNowControll;
