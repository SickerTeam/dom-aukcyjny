import Image from "next/image";
import { useEffect, useState } from "react";

type ArtworkCardType = {
  artwork: any;
  type: string;
};

const ArtworkCard = ({ artwork, type }: ArtworkCardType) => {
  const [href, setHref] = useState("");

  useEffect(() => {
    if (type === "instabuy") {
      setHref(`/buy-now/${artwork.id}`);
    } else {
      setHref(`/auctions/${artwork.id}`);
    }
  }, [artwork, type]);

  function timeUntil(dateTimeString: string): string {
    const targetDateTime: Date = new Date(dateTimeString);
    // Ensure targetDateTime is a valid Date object
    if (!(targetDateTime instanceof Date) || isNaN(targetDateTime.getTime())) {
      throw new Error("Invalid datetime provided");
    }

    // Get the current time
    const currentTime: Date = new Date();

    // Calculate the difference in milliseconds
    const timeDiff: number = targetDateTime.getTime() - currentTime.getTime();

    // Calculate days, hours, minutes, and seconds
    const days: number = Math.floor(timeDiff / (1000 * 60 * 60 * 24));
    const hours: number = Math.floor(
      (timeDiff % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60)
    );

    // Determine the appropriate unit based on the remaining time
    if (days > 0) {
      return `${days} day${days > 1 ? "s" : ""}`;
    } else {
      return `${hours} hour${hours !== 1 ? "s" : ""}`;
    }
  }

  return (
    <a href={href}>
      <div className="cursor-pointer">
        <Image
          src="/../cv2.png"
          alt="Zong logo"
          className="rounded-md drop-shadow-md "
          width={300}
          height={350}
        />
        <h1 className="w-full text-black text-2xl font-semibold  two-row-text">
          {`${artwork.product.title} by ${artwork.product.artist} (${artwork.product.year})`}
        </h1>
        <div className="text-neutral-500 text-base font-normal">
          {type === "auction" ? "CURRENT BID" : "BUY NOW"}
        </div>
        <h2 className="text-neutral-900 text-2xl font-semibold">
          {type === "instabuy"
            ? `€ ${artwork.price}`
            : `€ ${artwork.currentPrice}`}
        </h2>
        {type === "auction" && (
          <p className="text-neutral-500 text-base font-semibold">
            {`${timeUntil(artwork.endsAt)} left`}
          </p>
        )}
      </div>
    </a>
  );
};
export default ArtworkCard;
