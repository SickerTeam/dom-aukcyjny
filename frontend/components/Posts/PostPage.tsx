import PostCard from "./PostCard";
import SideRecommendation from "./SideRecommendation";
import SideNavigation from "./SideNavigation";


const PostPage = () => {
  return (
    <div className="flex justify-around">
      <div>
        <p>fuck this shit im not implementing it</p>
      </div>
      <div>
        {[...Array(10)].map((_, index) => (
          <PostCard key={index} />
        ))}
      </div>
      <div> 
        <SideRecommendation />
      </div>
    </div>
  );
};

export default PostPage;
