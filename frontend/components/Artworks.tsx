"use client";

import { useEffect, useState } from "react";
import ArtworkCard from "./ArtworkCard";
import apiService from "../services/apiService";

const Artworks = () => {
  const [auctions, setAuctions] = useState<[]>([]);

  useEffect(() => {
    apiService
      .get(`/Auctions`)
      .then((data) => setAuctions(data))
      .catch((error) => console.error("Error: ", error));
  }, []);

  return (
    <div className="grid grid-cols-6 gap-4">
      {auctions &&
        auctions.map((auction: any, index: number) => (
          <ArtworkCard key={index} artwork={auction} type="auction" />
        ))}
    </div>
  );
};

export default Artworks;
