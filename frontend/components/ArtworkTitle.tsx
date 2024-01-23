type ArtworkTitleType = {
  title: string;
};

const ArtworkTitle = ({ title }: ArtworkTitleType) => {
  return (
    <div>
      <h1 className="text-4xl">{title}</h1>
    </div>
  );
};

export default ArtworkTitle;
