import ProfilePostCard from "./ProfilePostCard";

type ProfilePostsType = {
  posts: any[];
};

const ProfilePosts = ({ posts }: ProfilePostsType) => {
  return (
    <div>
      <h2>Posts</h2>
      {posts.map((post) => (
        <ProfilePostCard key={post.id} post={post} />
      ))}
    </div>
  );
};

export default ProfilePosts;
