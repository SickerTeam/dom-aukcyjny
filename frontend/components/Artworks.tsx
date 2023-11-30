"use client";

import { useRouter } from "next/navigation";
import ArtworkCard from "./ArtworkCard";
import Link from "next/link";

interface IArtworks {
  artworks: any[];
}

const Artworks = ({ artworks }: IArtworks) => {
  const router = useRouter();

  // const handleOnCardClick = (id: number) => {
  //   // dispatch selected artwork, and then read the state
  //   router.push(`/auctions/${id}`);
  // };

  return (
    <div className="grid grid-cols-5 gap-4">
      {artworks.map((artwork, index) => (
        <Link
          href={{
            pathname: `/auctions/${artwork.id}`,
            query: artwork,
          }}
        >
          <ArtworkCard
            key={index}
            artwork={artwork}
            // handleClick={() => handleOnCardClick(artwork.id)}
          />
        </Link>
      ))}
    </div>
  );
};

export default Artworks;
