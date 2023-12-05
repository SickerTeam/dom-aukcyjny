import ArtistCard from "./ArtistCard";

const ArtistsOverview = () => {
  const artists = [
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
  ];

  return (
    <div className="main-artists-overview my-4">
      <h2 className="text-xl">
        Buy or bid on over{" "}
        <span className="italic text-main-green">2,137 objects</span> every
        week, created by{" "}
        <span className="italic text-main-green">420+ artists</span>
      </h2>
      <div className="flex gap-4 flex-wrap my-2">
        {artists.map((artist, index) => (
          <ArtistCard key={index} artist={artist} />
        ))}
      </div>
    </div>
  );
};

export default ArtistsOverview;
