type DiscoveryCardType = {
  picture: any;
};

const DiscoveryCard = ({ picture }: DiscoveryCardType) => {
  return (
    <div className="w-[200px] h-auto bg-main-green rounded shadow-sm"></div>
  );
};

export default DiscoveryCard;
