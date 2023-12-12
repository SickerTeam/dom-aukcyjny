import { Artworks, Filters, Path } from "..";
import apiService from "../../services/apiService";

async function getAllAuctions() {
  const res = await apiService.get("/auctions");

  if (!res.ok) {
    throw new Error("Failed to fetch auctions");
  }

  return res.json();
}

const AuctionsListPage = async () => {
  const auctions = await getAllAuctions();

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
