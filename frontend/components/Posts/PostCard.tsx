import { type } from "os";
import PictureCard from "./PictureCard";
import UserCard from "./UserCard";

async function getUserById(id: number) {
  const res = await fetch(`http://localhost:5156/User/${id}`);        
    if (!res.ok) {
      throw new Error("Failed to fetch nig");
    }
    return res.json();
}

type PostCardType = {
    post : any
}

const PostCard = async ({ post }: PostCardType) => {
  const user = await getUserById(post.userId);
  return (
    <div className="flex justify-center items-center flex-row">
      <div className="w-2/3">
        <div className=" ">
          <div className="mt-6">
            <ul className="flex flex-wrap text-sm leading-6 -mt-6 -mx-5">
              <UserCard user={user}/>
              <li className="flex items-center font-medium whitespace-nowrap px-5 mt-6 ml-auto">
                <div className="text-sm leading-4">
                  <div className="text-slate-900 dark:text-slate-400">20s</div>
                </div>
              </li>
            </ul>
          </div>
        </div>
        <p>{post.text}</p>
        <PictureCard/>
        <div className="likes-comments mt-4">
            <div>
              <span>{post.likes.length} likes </span>
              <span>{post.comments.length} comments</span>
            </div>
            <div className="flex items-center space-x-2"> {/* Use space-x utility class for horizontal spacing */}
                <img src="/../../comment.ico" alt="" />
                <img src="/../../like.ico" alt="" />
            </div>
        </div>
      </div>
    </div>
  );
};

export default PostCard;
