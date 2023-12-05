import ArtistsOverview from "./ArtistsOverview";
import Banner from "./Banner";
import DailyDiscovery from "./DailyDiscovery";
import PopularAuctions from "./PopularAuctions";

const Main = () => {
  return (
    <div className="flex flex-col gap-14">
      <Banner />
      <ArtistsOverview />
      <DailyDiscovery />
      <PopularAuctions />
    </div>
  );
};

export default Main;
