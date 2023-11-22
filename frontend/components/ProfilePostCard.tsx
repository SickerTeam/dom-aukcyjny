type ProfilePostCardType = {
  post: any;
};

const ProfilePostCard = ({ post }: ProfilePostCardType) => {
  return (
    <div className="w-full h-[200px] bg-gray-500 rounded my-2">{post}</div>
  );
};

export default ProfilePostCard;
