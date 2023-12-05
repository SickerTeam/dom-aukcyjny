type DiscoveryCardType = {
  picture: any;
};

const DiscoveryCard = ({ picture }: DiscoveryCardType) => {
  return <div className="w-[200px] h-auto bg-light-gray">{picture}</div>;
};

export default DiscoveryCard;
