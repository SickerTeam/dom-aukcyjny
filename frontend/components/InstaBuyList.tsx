"use client";

import { useEffect, useState } from "react";
import apiService from "../services/apiService";
import ArtworkCard from "./ArtworkCard";

const InstaBuyList = () => {
  const [instabuys, setInstabuys] = useState<[]>([]);

  useEffect(() => {
    apiService
      .get(`/fixedPriceListings`)
      .then((data) => setInstabuys(data))
      .catch((error) => console.error("Error: ", error));
  }, []);

  return (
    <div className="grid grid-cols-6 gap-4">
      {instabuys &&
        instabuys.map((instabuy: any, index: number) => (
          <ArtworkCard key={index} artwork={instabuy} type="instabuy" />
        ))}
    </div>
  );
};

export default InstaBuyList;
