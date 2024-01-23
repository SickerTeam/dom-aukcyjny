const AuctionDetails = ({ auction }) => {
  return (
    <div className="bg-light-gray rounded-lg shadow-sm p-4">
      <p>{auction.product.description}</p>
      <div className="grid grid-cols-2 grid-rows-auto my-4 gap-4">
        <div className="flex flex-col">
          <p className="font-bold">Year</p>
          <p>{auction.product.year}</p>
        </div>
        <div className="flex flex-col">
          <p className="font-bold">Condition</p>
          <p>Mint</p>
        </div>
        <div className="flex flex-col">
          <p className="font-bold">Artist</p>
          <p>{auction.product.artist}</p>
        </div>
        <div className="flex flex-col">
          <p className="font-bold">Title</p>
          <p>{auction.product.title}</p>
        </div>
        <div className="flex flex-col">
          <p className="font-bold">Height</p>
          <p>{auction.product.height} cm</p>
        </div>
        <div className="flex flex-col">
          <p className="font-bold">Width</p>
          <p>{auction.product.width} cm</p>
        </div>
        <div className="flex flex-col">
          <p className="font-bold">Depth</p>
          <p>{auction.product.depth} cm</p>
        </div>
        <div className="flex flex-col">
          <p className="font-bold">Weight</p>
          <p>{auction.product.weight} kg</p>
        </div>
      </div>
    </div>
  );
};

export default AuctionDetails;
