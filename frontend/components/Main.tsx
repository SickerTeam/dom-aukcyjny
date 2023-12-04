import ArtistCard from "./ArtistCard";
import PopularAuctionCard from "./PopularAuctionCard";

const Main = () => {
  const artists = [
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
    { name: "John Johny", specialization: "Boss of all the bosses" },
  ];
  const discoveryStuff = [1, 2, 3, 4, 5, 6];
  const popularAuctions = [
    {
      title: "Mona Lisa by Leonardo da Vinci (1503 - 1506)",
      currentBid: "€1,300,000",
      daysLeft: 2,
    },
    {
      title: "Mona Lisa by Leonardo da Vinci (1503 - 1506)",
      currentBid: "€1,300,000",
      daysLeft: 2,
    },
    {
      title: "Mona Lisa by Leonardo da Vinci (1503 - 1506)",
      currentBid: "€1,300,000",
      daysLeft: 2,
    },
    {
      title: "Mona Lisa by Leonardo da Vinci (1503 - 1506)",
      currentBid: "€1,300,000",
      daysLeft: 2,
    },
  ];

  return (
    <div>
      {/* wrap the main divs in a component like banner, recomended artist, daily ddiscovery */}
      <div className="grid grid-cols-4 grid-rows-3 gap-4 h-[700px] my-4">
        <div className="col-span-2 row-span-2 place-self-end">
          <h1 className="w-auto bg-gray-300 text-3xl">
            Here put some{" "}
            <span className="italic text-main-green">cool main</span> text...
          </h1>
        </div>
        <div className="col-start-1 row-start-3">
          <div className="col-span-2 row-span-2">
            <button type="button" className="rounded bg-light-gray py-2 px-10">
              <h3 className="text-lg">You are gay</h3>
            </button>
          </div>
        </div>
        <div className="col-span-2 row-span-3 col-start-3 row-start-1">
          <div className="col-span-2 row-span-2">
            <div className="w-full h-full bg-gray-300">asd</div>
          </div>
        </div>
      </div>
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
      <div className="daily-discovery-container grid bg-main-green h-[400px] p-4 my-4">
        <div className="self-center h-[300px] grid grid-cols-4 grid-rows-2 gap-4">
          <div className="self-center row-span-2 flex flex-col justify-between w-fit h-[200px]">
            <h3 className="text-2xl text-white tracking-wide">
              Your daily discovery
            </h3>
            <p className="text-darker-white">
              Log in and explore <br /> Zongers to get <br /> personalised
              finds.
              <br /> Updated daily.
            </p>
            <button
              type="button"
              className="rounded shadow-lg bg-light-gray italic py-2 px-10"
            >
              <h3 className="text-lg font-bold">Discover all</h3>
            </button>
          </div>
          <div className="col-span-3 row-span-2 flex gap-2">
            {discoveryStuff.map((stuff, index) => (
              <div key={index} className="w-[200px] h-auto bg-light-gray">
                {stuff}
              </div>
            ))}
          </div>
        </div>
      </div>
      <div className="main-popular-auctions-container">
        <h3 className="text-xl">Popular auctions</h3>
        <div className="flex gap-2">
          {popularAuctions.map((auction, index) => (
            <PopularAuctionCard key={index} auction={auction} />
          ))}
        </div>
      </div>
    </div>
  )
}

export default Main