"use client";

import { useEffect, useState } from "react";
import CountdownTimer from "../CountdownTimer";
import BidHistory from "./BidHistory";
import * as signalR from "@microsoft/signalr";
import BidControll from "../BidControll";
import apiService from "../../services/apiService";

type AuctionPanelType = {
  auction: any;
};

const AuctionPanel = ({ auction }: AuctionPanelType) => {
  const [currentPrice, setCurrentPrice] = useState(auction?.currentPrice || 0);

  useEffect(() => {
    if (auction) {
      setCurrentPrice(auction.currentPrice);
    }
  }, [auction?.currentPrice]);

  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:5156/bidHub")
      .build();

    connection.start().then(() => {
      console.log("Connected to SignalR Hub");
    });

    connection.on("CurrentPriceChanged", (amount) => {
      console.log(`New bid: ${amount}`);
      setCurrentPrice(amount);
    });

    return () => {
      connection.stop();
    };
  }, []);

  useEffect(() => {
    const fetchUserInfo = async () => {
      try {
        const user = await apiService.getUserInfo();
        console.log("User info:", user);
      } catch (error) {
        console.error("Error fetching user info:", error);
      }
    };

    // Execute fetchUserInfo only on the client side
    if (typeof window !== "undefined") {
      fetchUserInfo();
    }
  }, []);

  if (!auction) return <div>loading...</div>;

  return (
    <div>
      <CountdownTimer endsAt={auction.endsAt} />
      <div className="panel-container bg-light-gray p-2 ">
        <div className="panel-price-container my-2">
          <p className="current-bid uppercase">current bid</p>
          <h2>€ {currentPrice}</h2>
          <h4>
            {currentPrice >= auction.reservePrice
              ? "Reserve price met"
              : "Reserve price not met"}
          </h4>
        </div>
        <div className="panel-owner-container flex gap-2 my-2">
          <div className="w-[100px] h-[100px] bg-gray-500 rounded-full"></div>
          <div className="owner-texts">
            <h3 className="owner-estimate">
              Estimates € {auction.estimateMinPrice} - €{" "}
              {auction.estimateMaxPrice}
            </h3>
            <p className="go-to-owner-profile">
              {/* {`Go to ${auction.product.seller.firstName} ${auction.product.seller.lastName}'s profile`} */}
            </p>
          </div>
          {/* <div className="info-icon">
            <p>i</p>
          </div> */}
        </div>
        <div className="panel-bid-container my-2">
          <BidControll
            auctionId={auction.id}
            currentPrice={currentPrice ? currentPrice : auction.currentPrice}
          />
          {/* <div className="flex gap-2">
            <button className="border border-black rounded bg-white">
              Set max bid
            </button>
          </div> */}
        </div>
        <div className="panel-info-container my-2">
          <p>Buyer protection</p>
          <p>Shipping from & when</p>
          <p>Buyer protection fee</p>
          <p>Biding closes on ...</p>
        </div>
        <BidHistory history={auction.bids} />
      </div>
    </div>
  );
};

export default AuctionPanel;
