import DiscoveryCard from "./DiscoveryCard";

const DailyDiscovery = () => {
  const discoveryPictures = [1, 2, 3, 4, 5, 6, 7, 8, 9];

  return (
    <div className="grid bg-light-gray h-[400px] shadow-md full-bleed-gray">
      <div className="self-center h-[300px] grid grid-cols-4 grid-rows-2 gap-4">
        <div className="self-center row-span-2 flex flex-col justify-between w-fit h-[200px]">
          <h3 className="text-2xl text-black tracking-wide">
            Your daily discovery
          </h3>
          <p className="text-dark-gray">
            Log in and explore Zongers <br /> to get personalised finds.
            <br />
            <span className="font-semibold">Updated daily.</span>
          </p>
          <button
            type="button"
            className="rounded shadow-lg bg-main-green italic py-2 px-10"
          >
            <h3 className="text-lg text-white font-bold">Discover all</h3>
          </button>
        </div>
        <div className="col-span-3 row-span-2 flex gap-2 justify-between">
          {discoveryPictures.map((picture, index) => (
            <DiscoveryCard key={index} picture={picture} />
          ))}
        </div>
      </div>
    </div>
  );
};

export default DailyDiscovery;
