import { Artworks, Filters, Path } from "..";

const AuctionsListPage = () => {
  return (
    <div>
      <div className="mb-4">
        <Path />
      </div>
      <Filters />
      <Artworks />
    </div>
  );
};

export default AuctionsListPage;
