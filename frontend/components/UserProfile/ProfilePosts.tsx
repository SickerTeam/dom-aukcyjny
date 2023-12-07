import ProfilePostCard from "./ProfilePostCard";

const ProfilePosts = () => {
  // fetcj posts here
  const posts = ["Post 1", "Post 2", "Post 3"];

  return (
    <div>
      <h2>Posts</h2>
      <div className="grid grid-cols-1 gap-4">
        {posts.map((post, index) => (
          <ProfilePostCard key={index} post={post} />
        ))}
      </div>
    </div>
  );
};

export default ProfilePosts;
