"use client"

import { useState, useEffect } from 'react'


import PostCard from "./PostCard";
import UserCard from "./UserCard";
import SideNavigation from "./SideNavigation";
import PostAPost from "./PostAPost";


interface User {
  id: number;
}

export default function PostPage() {
  const [posts, setPosts] = useState([]);
  const [users, setUsers] = useState<User[]>([]);
  const postsr = [...posts].reverse();

  useEffect(() => {
    fetch('https://localhost:5156/Users')
      .then((res) => {
        res.json().then((data) => {
          console.log(data)
          setUsers(data);
        });
      }).catch((error) => console.error(error));

    fetch('https://localhost:5156/Posts')
      .then((res) => {
        res.json().then((data) => {
          setPosts(data);
        });
      })
      .catch((error) => console.error(error));
  }, []);

  return (
      <div className="ml-10 ...">
      <div className="flex justify-around h-full">
        <div className='w-1/3'>
          <SideNavigation/>
        </div>
        <div className='w-1/3'>
            <PostAPost/>
            {postsr.map((post: any, index: number) => <PostCard key={index} post={post} user={post.user} />)}
        </div>
        <div className='w-1/3 '>
          {users.map((user: User) => (
            <UserCard key={user.id} user={user} />
          ))}
        </div>
      </div>
      </div>
  );
}

