import { ProfilePhoto, ProfileDetails, ProfilePosts, AboutMe } from "..";
import ProfileArtworks from "./ProfileArtworks";
import ProfileArchive from "./ProfileArchive";

type UserPageType = {
  userId: string;
};

const UserPage = ({ userId }: UserPageType) => {
  // fetch user profile info with the user id from params.id, later the user profile object that
  // we receive will have certain type with all the properties needed
  const userProfileInfo = {
    name: "Gabriel Pedlowski",
    photoUrl: "https://www.something.com/",
    country: "Poland",
    aboutMe:
      "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.",
    socialFb: "https://www.facebook.com/",
    socialIg: "https://www.instagram.com/",
    socialYt: "https://www.youtube.com/",
  };

  return (
    <div className="grid grid-cols-6 grid-rows-6 gap-4 pt-12">
      <div className="row-span-2">
        <ProfilePhoto
          url={userProfileInfo.photoUrl}
          name={userProfileInfo.name}
        />
      </div>
      <div className="col-span-2 row-span-2">
        <AboutMe description={userProfileInfo.aboutMe} />
      </div>
      <div className="col-span-2 row-span-6 col-start-5">
        <ProfilePosts />
      </div>
      <div className="row-span-4 row-start-3">
        <ProfileDetails
          name={userProfileInfo.name}
          country={userProfileInfo.country}
        />
      </div>
      <div className="col-span-3 row-span-2 row-start-3">
        <ProfileArtworks />
      </div>
      <div className="col-span-3 row-span-2 col-start-2 row-start-5">
        <ProfileArchive />
      </div>
    </div>
  );
};

export default UserPage;
