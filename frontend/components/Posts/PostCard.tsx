import { type } from "os";
import PictureCard from "./PictureCard";
import UserCard from "./UserCard";

async function getUserById(id: number) {
  const res = await fetch(
    `https://sea-turtle-app-yvb56.ondigitalocean.app/User/${id}`
  );
  if (!res.ok) {
    throw new Error("Failed to fetch nig");
  }
  return res.json();
}

type PostCardType = {
  post: any;
};

const calculateTimeAgo = (post: any) => {
  const postTime = new Date(post.timePosted);
  const currentTime = new Date();
  const timeDifference = currentTime.getTime() - postTime.getTime();

  const minutesDifference = Math.floor(timeDifference / (1000 * 60));
  const hoursDifference = Math.floor(timeDifference / (1000 * 60 * 60));
  const daysDifference = Math.floor(timeDifference / (1000 * 60 * 60 * 24));

  return daysDifference > 0
    ? `${daysDifference} days ago`
    : hoursDifference > 0
    ? `${hoursDifference} hours ago`
    : `${minutesDifference} minutes ago`;
};

const PostCard = async ({ post }: PostCardType) => {
  const user = await getUserById(post.userId);
  const timeAgo = calculateTimeAgo(post);
  return (
    <div className="flex justify-center items-center flex-row">
      <div className="w-2/3">
        <div className=" ">
          <div className="mt-6">
            <ul className="flex flex-wrap text-sm leading-6 -mt-6 -mx-5">
              <UserCard user={user} />
              <li className="flex items-center font-medium whitespace-nowrap px-5 mt-6 ml-auto">
                <div className="text-sm leading-4">
                  <div className="text-slate-900 dark:text-slate-400">
                    {timeAgo}
                  </div>
                </div>
              </li>
            </ul>
          </div>
        </div>
        <p>{post.text}</p>
        <PictureCard />
        <div className="likes-comments mt-4">
          <div>
            <span>{post.likes.length} likes </span>
            <span>{post.comments.length} comments</span>
          </div>
          <div className="flex items-center space-x-2">
            {" "}
            {/* Use space-x utility class for horizontal spacing */}
            <img src="/../../comment.ico" alt="" />
            <img src="/../../like.ico" alt="" />
          </div>
        </div>
      </div>
    </div>
  );
};

export default PostCard;
