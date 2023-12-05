import PictureCard from "./PictureCard";
import UserCard from "./UserCard";




const PostCard = () => {
  return (
    <div className="flex justify-center items-center flex-row">
      <div className="w-2/3">
        <div className=" ">
          <div className="mt-6">
            <ul className="flex flex-wrap text-sm leading-6 -mt-6 -mx-5">
              <UserCard />
              <li className="flex items-center font-medium whitespace-nowrap px-5 mt-6 ml-auto">
                <div className="text-sm leading-4">
                  <div className="text-slate-900 dark:text-slate-400">20s</div>
                </div>
              </li>
            </ul>
          </div>
        </div>
        <p>Fuck niggas</p>
        <PictureCard/>
        <div className="likes-comments mt-4">
            <div className="flex items-center space-x-2"> {/* Use space-x utility class for horizontal spacing */}
                <img src="/../../comment.ico" alt="" />
                <img src="/../../like.ico" alt="" />
            </div>
          <div className="likes">
            <i className="fa fa-thumbs-up rounded"></i>
            <span>10 Likes</span>
          </div>
          <div className="comments">
            <span>5 Comments</span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default PostCard;
