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

  const formatDate = (dateString: string): string => {
    const date = new Date(dateString);
    const options: Intl.DateTimeFormatOptions = {
      year: "numeric",
      month: "long",
      day: "numeric",
      hour: "numeric",
      minute: "numeric",
      second: "numeric",
    };
    const formattedDate: string = date.toLocaleDateString("en-US", options);
    return formattedDate;
  };

  if (!auction) return <div>loading...</div>;

  return (
    <div className="w-full">
      <div className="pl-4">
        <CountdownTimer endsAt={auction.endsAt} />
      </div>
      <div className="bg-light-gray rounded-lg p-4 w-full">
        <div className="panel-price-container mb-2">
          <p className="current-bid uppercase font-bold">current bid</p>
          <h2 className="text-4xl">€ {currentPrice}</h2>
          <h4>
            {currentPrice >= auction.reservePrice
              ? "Reserve price met"
              : "Reserve price not met"}
          </h4>
        </div>
        <div className="panel-owner-container flex gap-4 my-4 items-center">
          <div className="w-[100px] h-[100px] bg-white rounded-full"></div>
          <div className="owner-texts">
            <h3 className="text-lg">
              Estimates € {auction.estimateMinPrice} - €{" "}
              {auction.estimateMaxPrice}
            </h3>
          </div>
        </div>

        <div className="panel-bid-container my-4 w-3/4">
          <BidControll
            auctionId={auction.id}
            currentPrice={currentPrice ? currentPrice : auction.currentPrice}
          />
        </div>
        <div className="panel-info-container my-4">
          <p>Buyer protection</p>
          <p>Shipping information</p>
          <p>Buyer protection fee</p>
          <p>Biding closes on {formatDate(auction.endsAt)}</p>
        </div>
        <hr className="my-4" />
        <BidHistory history={auction.bids} />
      </div>
    </div>
  );
};

export default AuctionPanel;
