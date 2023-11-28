"use client";

import { useRouter } from "next/navigation";
import ArtworkCard from "./ArtworkCard";

interface IArtworks {
  artworks: any[];
}

const Artworks = ({ artworks }: IArtworks) => {
  const router = useRouter();

  const handleOnCardClick = (id: number) => {
    router.push(`/artworks/${id}`);
  };

  return (
    <div className="grid grid-cols-5 gap-4 m-10">
      {artworks.map((artwork, index) => (
        <ArtworkCard
          key={index}
          artwork={artwork}
          handleClick={() => handleOnCardClick(artwork.id)}
        />
      ))}
    </div>
  );
};

export default Artworks;
