import { Suspense } from "react";
import { Artworks, Filters, Path } from "..";

const AuctionsListPage = () => {
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
