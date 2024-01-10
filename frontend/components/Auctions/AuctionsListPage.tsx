import { Artworks, Filters, Path } from "..";

const AuctionsListPage = () => {
  return (
    <div>
      <Path />
      <Filters />

      {/* <Suspense fallback={<div>Loading...</div>}> */}
      <Artworks />
      {/* </Suspense> */}
    </div>
  );
};

export default AuctionsListPage;
