import { Artworks, Filters, Path } from "..";

const AuctionsListPage = () => {
  return (
    <div>
      <Filters />

      {/* <Suspense fallback={<div>Loading...</div>}> */}
      <Artworks />
      {/* </Suspense> */}
    </div>
  );
};

export default AuctionsListPage;
