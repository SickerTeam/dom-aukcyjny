"use client";

import ArtworkCard from "./ArtworkCard";

interface IArtworks {
  artworks: any[];
}

const Artworks = ({ artworks }: IArtworks) => {
  return (
    <div className="grid grid-cols-6 gap-4">
      {artworks.map((artwork, index) => (
        <ArtworkCard key={index} artwork={artwork} />
      ))}
    </div>
  );
};

export default Artworks;