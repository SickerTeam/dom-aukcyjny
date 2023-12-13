import ProfileArtworksCard from "./ProfileArtworksCard";

const ProfileArtworks = () => {
  const artworks = ["Artworks 1", "Artworks 2", "Artworks 3"];
  //  limit the posts visible to be only 3

  return (
    <div>
      <h2>Artworks</h2>
      <div className="flex gap-2">
        {artworks.map((artwork, index) => (
          <ProfileArtworksCard key={index} artwork={artwork} />
        ))}
      </div>
    </div>
  );
};

export default ProfileArtworks;
