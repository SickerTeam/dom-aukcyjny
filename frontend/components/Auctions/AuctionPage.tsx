"use client";

import { useEffect, useState } from "react";
import {
  ArtworkTitle,
  AuctionDetails,
  AuctionPanel,
  Path,
  PhotoDisplay,
} from "..";
import apiService from "../../services/apiService";

type AuctionPageType = {
  id: string;
};

const AuctionPage = ({ id }: AuctionPageType) => {
  const [auction, setAuction] = useState({ title: "", photos: [] });

  useEffect(() => {
    apiService
      .get(`/auction/${id}`)
      .then((data) => setAuction(data))
      .catch((error) => console.error("Error: ", error));
  }, [id]);

  return (
    <div className="grid grid-cols-4 grid-rows-7 gap-4 px-40">
      <div className="col-span-3 row-span-5">
        <Path />
        <ArtworkTitle title={auction.title} />
        <PhotoDisplay photos={auction.photos} />
      </div>
      <div className="row-span-3 col-start-4">
        <AuctionPanel auction={auction} />
      </div>
      <div className="col-span-3 row-span-2 row-start-6 h-full bg-gray-300">
        <AuctionDetails />
      </div>
    </div>
  );
};

export default AuctionPage;