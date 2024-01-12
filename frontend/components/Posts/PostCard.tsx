"use client";

import { useEffect, useState } from 'react';
import PictureCard from './PictureCard';
import UserCard from './UserCard';
import User from '@/app/users/[id]/page';


type PostCardType = {
  post: any;
  user: {
    imageLink: string;
  }
};

const calculateTimeAgo = (post: any) => {
  const postTime = new Date(post.createdAt);
  postTime.setHours(postTime.getHours() + 1 );
  const currentTime = new Date();
  const timeDifference = currentTime.getTime() - postTime.getTime();

  const minutesDifference = Math.floor(timeDifference / (1000 * 60));
  const hoursDifference = Math.floor(timeDifference / (1000 * 60 * 60));
  const daysDifference = Math.floor(timeDifference / (1000 * 60 * 60 * 24));

  return daysDifference > 0
    ? `${daysDifference} days ago`
    : hoursDifference > 0
    ? `${hoursDifference} hours ago`
    : `${minutesDifference} minutes ago`;
};



export default function PostCard({post}: PostCardType){
  const [user, setUser] = useState();
  const userId = 4;

  useEffect(() => {
    fetch(`https://localhost:5156/Users/${post.userId}`)
      .then((res) => {
        res.json().then((data) => {
          console.log(data+"user")
          setUser(data);
        });
      }).catch((error) => console.error(error));
  }, []);

  const timeAgo = calculateTimeAgo(post);

  
  function handleLike() {
    const requestBody = {
      userId: userId,
      postId: post.id,
    };
  
    fetch("https://localhost:5156/Likes", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(requestBody),
    })
      .then((res) => {
        res.json().then((data) => {
          console.log("we just posted brother");
          setUser(data);
        });
      })
  }

  return (
    <div className="flex justify-center items-center flex-row">      
      <div className="mx-auto">
        <div className=" ">
          <div className="mt-6">
            <ul className="flex flex-wrap text-sm leading-6 -mt-6 -mx-5">
              <div> <UserCard user={post && post.user} /> </div>
              <li className="flex items-center font-medium whitespace-nowrap px-5 mt-6 ml-auto">
                <div className="text-sm leading-4">
                  <div className="text-slate-900 dark:text-slate-400">{timeAgo}</div>
                </div>
              </li>
            </ul>
          </div>
        </div>
        <p>{post && post.text}</p>
        <div>
          <PictureCard image={post && post.imageLink} />
        </div>        
        <div className="likes-comments mt-4">
          <div>
            <span>{post.likes.length} likes </span>
            <span>{post.comments.length} comments</span>
          </div>
          <div className="flex items-center space-x-2">
            {/* Use space-x utility class for horizontal spacing */}
            <img src="/../../comment.ico " alt="" />
            <img src="/../../like.ico" alt="" />
          </div>
        </div>
      </div>
    </div>
  );
};



/*

"use client";
import React from "react";



export default function PostPage() {
  const [dateTime, setDateTime] = React.useState<string>();
 
  React.useEffect(() => {
    fetch('https://worldtimeapi.org/api/ip')
      .then((res) => {
        res.json().then((data) => {
          console.log("");
          setDateTime(data.datetime);
        });
      })
      .catch((error) => console.error(error));
  }, []);
 
  return (
    <main>
      <p>Current time: {dateTime}</p>
    </main>
  );
}*/
