import { ProfilePhoto, ProfileDetails, ProfilePosts, AboutMe } from "..";
import ProfileArtworks from "../UserProfile/ProfileArtworks";
import ProfileArchive from "../UserProfile/ProfileArchive";

type UserPageType = {
  userId: string;
};

const UserPage = ({ userId }: UserPageType) => {
  const userProfileInfo = {
    name: "Jakob Hujek",
    photoUrl: "",
    country: "Poland",
    aboutMe: "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
    socialFb: "https://www.facebook.com/",
    socialIg: "https://www.instagram.com/",
    socialYt: "https://www.youtube.com/",
  };

  return (
    <div className='flex'>
      <div className="sidebar text-black w-1/5 p-8 mt-12">
        <ul>
          <li className="mb-2"><a href="/yourprofile/edit">Settings</a></li>
          <li className="mb-2"><a href="/yourprofile/addresses">Addresses</a></li>
          <li className="mb-2"><a href="/yourprofile/payments">Payments</a></li>
          <li className="mb-2"><a href="/yourprofile/myfavourites">My favourites</a></li>
        </ul>
      </div>
      <div className="grid grid-cols-6 gap-2 pt-8">
        <div className="col-start-2 ">
          <ProfilePhoto
            url={userProfileInfo.photoUrl}
            name={userProfileInfo.name}
          />
        </div>
        <div className="col-start-3 col-span-4 flex ml-14 mt-6">
          <ProfileDetails
            name={userProfileInfo.name}
            country={userProfileInfo.country}
          />
        </div>
        <div className="col-start-2 col-span-4 mb-8 mt-8">
          <AboutMe description={userProfileInfo.aboutMe} />
        </div>
        <div className="col-start-2 col-span-4 ">
          <ProfilePosts />
        </div>
        <div className="col-start-2 col-span-4">
          <ProfileArtworks />
        </div>
        <div className="col-start-2 col-span-4">
          <ProfileArchive />
        </div>
      </div>
    </div>
  );
};

export default UserPage;
