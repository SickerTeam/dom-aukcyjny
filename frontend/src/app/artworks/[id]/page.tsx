import Path from "../../../../components/Path";

type ArtworkPageType = {
  params: {
    id: string;
  };
};

const ArtworkPage = ({ params }: ArtworkPageType) => {
  return (
    <div>
      <Path />
      {params.id}
    </div>
  );
};

export default ArtworkPage;
