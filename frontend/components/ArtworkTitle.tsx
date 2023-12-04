type ArtworkTitleType = {
  title: string;
};

const ArtworkTitle = ({ title }: ArtworkTitleType) => {
  return <div>{title}</div>;
};

export default ArtworkTitle;
