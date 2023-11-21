import { ProfilePhoto, ProfileDetails, AboutMe } from "../../../../components";

type UsersPageType = {
  params: {
    id: string;
  };
};

const UsersPage = ({ params }: UsersPageType) => {
  const userId = params.id;

  // fetch user profile info with the user id from params.id, later the user profile object that
  // we receive will have certain type with all the properties needed
  const userProfileInfo = {
    name: "Gabriel Pedlowski",
    // photoUrl: "https://www.something.com/",
    country: "Poland",
    aboutMe:
      "Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source.",
    socialFb: "https://www.facebook.com/",
    socialIg: "https://www.instagram.com/",
    socialYt: "https://www.youtube.com/",
  };

  // also need to fetch artworks, archived and posts with
  const artworks = [];
  const archive = [];
  const posts = [{}];

  return (
    <div className="flex">
      <div className="flex-1 ">
        {/* <ProfilePhoto
          url={userProfileInfo.photoUrl}
          name={userProfileInfo.name}
        /> */}
        <ProfileDetails name={userProfileInfo.name} />
      </div>
      <div className="flex-1 ">
        <AboutMe description={userProfileInfo.aboutMe} />
        {/* <ProfileArtworks /> */}
        {/* <ProfileArchive /> */}
      </div>
      <div className="flex-1 ">
        <ProfilePosts posts={posts} />
      </div>
    </div>
  );
};

export default UsersPage;
