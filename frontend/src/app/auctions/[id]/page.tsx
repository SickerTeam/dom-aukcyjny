import { AuctionPage } from "../../../../components";

type AuctionType = {
  params: {
    id: string;
  };
};

const Auction = ({ params }: AuctionType) => {
  return <AuctionPage id={params.id} />;
};

export default Auction;
