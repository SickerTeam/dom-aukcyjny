type ProfilePhotoType = {
  url: string;
  name: string;
};

const ProfilePhoto = ({ url, name }: ProfilePhotoType) => {
  // dont know how we handle storing photos, if AWS or smth else than storing
  // directly in DB - have to fetch it at some point i guess
  const alt = `Profile photo of ${name}`;
  // <Image src={url} alt={alt} height={200} width={200} />;

  return (
    <div className="w-[200px] h-[200px] bg-gray-500 rounded-full">yooo</div>
  );
};

export default ProfilePhoto;
