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
      <h1>{firstName}</h1>
      <h1>{lastName}</h1>
      <h2>{country}</h2>
    </div>
  );
};

export default ProfileDetails;
