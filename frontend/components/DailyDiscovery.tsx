import DiscoveryCard from "./DiscoveryCard";

const DailyDiscovery = () => {
  const discoveryPictures = [1, 2, 3, 4, 5, 6];

  return (
    <div className="daily-discovery-container grid bg-main-green h-[400px] p-4 my-4">
      <div className="self-center h-[300px] grid grid-cols-4 grid-rows-2 gap-4">
        <div className="self-center row-span-2 flex flex-col justify-between w-fit h-[200px]">
          <h3 className="text-2xl text-white tracking-wide">
            Your daily discovery
          </h3>
          <p className="text-darker-white">
            Log in and explore <br /> Zongers to get <br /> personalised finds.
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
          {discoveryPictures.map((picture, index) => (
            <DiscoveryCard key={index} picture={picture} />
          ))}
        </div>
      </div>
    </div>
  );
};

export default DailyDiscovery;
