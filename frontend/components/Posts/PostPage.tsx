import { createVerify } from "crypto";
import PostCard from "./PostCard";
import SideRecommendation from "./SideRecommendation";



async function getAllPosts() {
    const res = await fetch("https://sea-turtle-app-yvb56.ondigitalocean.app/Post");

    if (!res.ok) {
      throw new Error("Failed to fetch auctions");
    }
  
    return res.json();
}

async function getAllUsers() {
  const res = await fetch("https://sea-turtle-app-yvb56.ondigitalocean.app/User");

        
    if (!res.ok) {
      throw new Error("Failed to fetch auctions");
    }
  
    return res.json();
}


const PostPage = async () => {
    const posts = await getAllPosts();
    const users = await getAllUsers();
    
  return (
    <div className="flex justify-around">
      <div>
        <p>fuck this shit im not implementing it</p>
      </div>
      <div>
      {posts.map((post: any, index: number) => <PostCard key={index} post={post} />)}
      </div>
      <div> 
        <SideRecommendation user={users}/>
      </div>
    </div>
  );
};

export default PostPage;
