"use client";

import Image from "next/image";

interface IArtworkCard {
  artwork: any;
  handleClick: () => void;
}

const ArtworkCard = ({ artwork, handleClick }: IArtworkCard) => {
  return (
    <div className="cursor-pointer" onClick={handleClick}>
      <Image
        src="/../cv2.png"
        alt="Zong logo"
        className="object-fill h-300 w-350 rounded-md drop-shadow-md "
        width={300}
        height={350}
      />
      <h1 className="w-full text-black text-2xl font-semibold font-['Playfair Display']">
        {artwork.title}
      </h1>
      <div className="text-neutral-500 text-base font-normal font-['Source Sans Pro']">
        CURRENT BID
      </div>
      <h2 className="text-neutral-900 text-2xl font-semibold font-['Source Sans Pro']">
        €{artwork.price}
      </h2>
      <p className="text-neutral-500 text-base font-semibold font-['Source Sans Pro']">
        {artwork.time} days left
      </p>
    </div>
  );
};
export default ArtworkCard;
