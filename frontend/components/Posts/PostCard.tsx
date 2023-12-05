import UserCard from "./UserCard";

const PostCard = () => {
  return (
    <div className="flex justify-center items-center flex-row">
      <div className="w-1/5">
        <div className="w-full ">
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

        <img className="rounded-md" src="/../../cv3.png" alt="Post Image" />
        <div className="likes-comments">
          <div className="likes">
            <i className="fa fa-thumbs-up rounded"></i>
            <span>10 Likes</span>
          </div>
          <div className="comments">
            <i className="fa-solid fa-comment"></i>
            <span>5 Comments</span>
          </div>
        </div>
      </div>
    </div>
  );
};

export default PostCard;
