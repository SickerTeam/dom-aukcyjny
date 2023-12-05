import PostCard from "./PostCard"
import SideRecommendation from "./SideRecommendation";


const PostPage = () => {
    return (
        
        <div>
            {[...Array(10)].map((_, index) => (
                <PostCard key={index} />
            ))}
            <SideRecommendation/>
        </div>
    );
};

export default PostPage;
