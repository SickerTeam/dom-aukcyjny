"use client";

import { useEffect, useState } from "react";
import apiService from "../../../../services/apiService";
import {
  ArtworkTitle,
  AuctionDetails,
  Path,
  PhotoDisplay,
} from "../../../../components";
import BuyNowPanel from "../../../../components/BuyNowPanel";

type AuctionType = {
  params: {
    id: string;
    auction: any;
  };
};

const BuyNowItemPage = ({ params }: AuctionType) => {
  const photos = [1, 2, 3, 4, 5, 6, 7, 8];
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
        <Path title={buyNow.product.title} />
        <ArtworkTitle title={buyNow.product.title} />
        <PhotoDisplay photos={photos} />
      </div>
      <div className="row-span-3 col-start-4">
        <BuyNowPanel buyNow={buyNow} />
      </div>
      <div className="col-span-3 row-span-2 row-start-6">
        <AuctionDetails auction={buyNow} />
      </div>
    </div>
  );
};

export default BuyNowItemPage;
