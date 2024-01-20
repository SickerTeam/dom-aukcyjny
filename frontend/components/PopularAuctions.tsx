"use client";
import {  useEffect, useState } from "react";
import PopularAuctionCard from "./PopularAuctionCard";
import apiService from "../services/apiService";

const PopularAuctions = () => {
  const [popularAuctions, setpopularAuctions] = useState([]);
  useEffect(() => {
    const fetchAuction = async () => {
      try {
        const response = await apiService.get(`/Auctions`);
        setpopularAuctions(response);
        console.log(response);
      } catch (error) {
        console.error(error);
      }
    };
    fetchAuction();
  }, []);
  

  return (
    <div className=" ">
      <h3 className="text-xl">Popular auctions</h3>
      <div className="flex gap-6">
        {popularAuctions.map((auction, index) => (
          <PopularAuctionCard key={index} auction={auction} />
        ))}
      </div>
    </div>
  );
};

export default PopularAuctions;
