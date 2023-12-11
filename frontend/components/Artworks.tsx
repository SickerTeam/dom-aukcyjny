"use client";

import { useEffect, useState } from "react";
import ArtworkCard from "./ArtworkCard";
import apiService from "../services/apiService";

const Artworks = async () => {
  // const [auctions, setAuctions] = useState<[]>([]);

  const auctions = await apiService.get(`/auction`);
  console.log(auctions);

  // useEffect(() => {
  //   apiService
  //     .get(`/auction`) // still need to change the names of controllers xd
  //     .then((data) => setAuctions(data))
  //     .catch((error) => console.error("Error: ", error));
  // }, []);

  return (
    <div className="grid grid-cols-6 gap-4">
      {auctions &&
        auctions.map((auction: any, index: number) => (
          <ArtworkCard key={index} artwork={auction} />
        ))}
    </div>
  );
};

export default Artworks;

// pass the auction with nested product object inside of it, in the service layer then create a product based the object passed with auction, and then pass the created product to the auction creation
