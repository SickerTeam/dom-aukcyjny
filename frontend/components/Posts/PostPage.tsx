"use client"
import React, { use, useEffect, useState } from "react";
import PostCard from "./PostCard";
import SideRecommendation from "./SideRecommendation";

const PostPage = () => {
  const [posts, setPosts] = useState([]);
  const [users, setUsers] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const postsResponse = await fetch("http://localhost:5156/Posts");
        const usersResponse = await fetch("http://localhost:5156/Users");

        if (!postsResponse.ok) {
          throw new Error("Failed to fetch posts");
        }

        if (!usersResponse.ok) {
          throw new Error("Failed to fetch users");
        }

        const postsData = await postsResponse.json();
        const usersData = await usersResponse.json();

        setPosts(postsData);
        setUsers(usersData);
      } catch (error) {
        console.error("Error fetching data:", error as Error);
      }
    };

    fetchData();
  }, []); // Empty dependency array ensures the effect runs only once on mount

  const postPost = (event: React.MouseEvent<HTMLButtonElement>) => {
    event.preventDefault(); // Prevent page refresh
    console.log("posting post");
    // Add logic for posting a new post if needed
  };

  return (
    <div>
      <div className="flex flex-col items-center">
        <form>
          <button
            className="6 m-2 flex border-solid border-2 border-grey-500 inline-block rounded-lg"
            onClick={postPost}
          >
            Post
          </button>
        </form>
        <div className="flex justify-around">
          <div>
            <p>fuck this shit im not implementing it</p>
          </div>
          <div>
            {posts.map((post: any, index: number) => (
              <PostCard key={index} post={post} />
            ))}
          </div>
          <div>
            <SideRecommendation user={users} />
          </div>
        </div>
      </div>
    </div>
  );
};

export default PostPage;
