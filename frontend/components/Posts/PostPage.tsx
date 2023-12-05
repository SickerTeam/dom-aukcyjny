import PostCard from "./PostCard";
import SideRecommendation from "./SideRecommendation";

const PostPage = () => {
  return (
    <div className="flex justify-around">
      <div>something else</div>
      <div>
        {[...Array(10)].map((_, index) => (
          <PostCard key={index} />
        ))}
      </div>
      <div>
        recommendations
        <SideRecommendation />
      </div>
    </div>
  );
};

export default PostPage;
