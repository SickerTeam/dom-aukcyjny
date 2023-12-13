import { Artworks, Filters, Path } from "..";

const AuctionsListPage = async () => {
  return (
    <div className="px-40">
      <Path />
      <Filters />

      {/* <Suspense fallback={<div>Loading...</div>}> */}
      <Artworks />
      {/* </Suspense> */}
    </div>
  );
};

export default AuctionsListPage;
