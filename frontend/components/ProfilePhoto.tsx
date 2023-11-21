import Image from "next/image";

type ProfilePhotoType = {
  url: string;
  name: string;
};

const ProfilePhoto = ({ url, name }: ProfilePhotoType) => {
  // dont know how we handle storing photos, if AWS or smth else than storing
  // directly in DB - have to fetch it at some point i guess
  const alt = `Profile photo of ${name}`;

  return <Image src={url} alt={alt} height={200} width={200} />;
};

export default ProfilePhoto;
