type ProfileDetailsType = {
  name: string;
  country: string;
};

const ProfileDetails = ({ name, country }: ProfileDetailsType) => {
  const namesArray = name.split(" ");

  const firstName = namesArray[0];
  const lastName = namesArray.slice(1).join(" ");

  return (
    <div>
      <h1 className="inline-block text-2xl font-semibold">{name}</h1>
      <h2 className=" font-semibold">{country}</h2>
    </div>
  );
};

export default ProfileDetails;
