type ArtistCardType = {
  artist: any;
};

const ArtistCard = ({ artist }: ArtistCardType) => {
  return (
    <div>
      <div className="w-[300px] h-[300px] bg-light-gray rounded"></div>
      <h3 className="font-semibold">{artist.name}</h3>
      <p>{artist.specialization}</p>
    </div>
  );
};

export default ArtistCard;
