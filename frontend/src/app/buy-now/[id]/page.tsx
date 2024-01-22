"use client";

import { useEffect, useState } from "react";
import apiService from "../../../../services/apiService";
import { ArtworkTitle, AuctionDetails } from "../../../../components";
import BuyNowPanel from "../../../../components/BuyNowPanel";

type AuctionType = {
  params: {
    id: string;
    auction: any;
  };
};

const BuyNowItemPage = ({ params }: AuctionType) => {
  const [buyNow, setBuyNow] = useState({ product: { title: "" } });

  useEffect(() => {
    apiService
      .get(`/fixedPriceListings/${params.id}`)
      .then((data) => setBuyNow(data))
      .catch((error) => console.error("Error: ", error));
  }, [params]);

  return (
    <div className="grid grid-cols-4 grid-rows-7 gap-4  ">
      <div className="col-span-3 row-span-5">
        {/* <Path title={auction.product.title} /> */}
        <ArtworkTitle title={buyNow.product.title} />
        {/* <PhotoDisplay photos={auction.photos} /> */}
      </div>
      <div className="row-span-3 col-start-4">
        <BuyNowPanel buyNow={buyNow} />
      </div>
      <div className="col-span-3 row-span-2 row-start-6 h-full bg-gray-300">
        <AuctionDetails />
      </div>
    </div>
  );
};

export default BuyNowItemPage;
