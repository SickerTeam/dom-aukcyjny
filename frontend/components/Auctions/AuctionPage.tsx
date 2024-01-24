"use client";

import { useEffect, useState } from "react";
import { ArtworkTitle, AuctionDetails, AuctionPanel, PhotoDisplay } from "..";
import apiService from "../../services/apiService";

const AuctionPage = ({ id }: any) => {
  const photos = [
    "https://zongbucket.s3.eu-north-1.amazonaws.com/Products/6",
    "https://zongbucket.s3.eu-north-1.amazonaws.com/Products/7",
    "https://zongbucket.s3.eu-north-1.amazonaws.com/Products/8",
  ];

  const [auction, setAuction] = useState({ product: { title: "" } });

  useEffect(() => {
    apiService
      .get(`/Auctions/${id}`)
      .then((data) => setAuction(data))
      .catch((error) => console.error("Error: ", error));
      console.log(auction)
  }, [id]);

  return (
    <div className="grid grid-cols-4 grid-rows-7 gap-4">
      <div className="col-span-3 row-span-5">
        <ArtworkTitle title={auction.product.title} />
        <PhotoDisplay photos={photos} />
      </div>
      <div className="row-span-3 col-start-4">
        <AuctionPanel auction={auction} />
      </div>
      <div className="col-span-3 row-span-2 row-start-6">
        <AuctionDetails auction={auction} />
      </div>
    </div>
  );
};

export default AuctionPage;
