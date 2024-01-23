"use client";

import Image from "next/image";
const UserCard = ({ user: user }: { user: any }) => {
  return (
    user && (
      <div>
        <li className="flex items-center font-medium whitespace-nowrap px-5 mt-6">
          <Image
            src={`${user.imageLink}` || "/../../cv3.png"}
            alt=""
            className="mr-3 w-9 h-9 rounded-full bg-slate-50 dark:bg-slate-800"
            decoding="async"
            width={500}
            height={500}
          />
          <div className="text-sm leading-4">
            <div className="text-slate-900 dark:text-slate-800">
              {user.firstName} {user.lastName}
            </div>
          </div>
        </li>
      </div>
    )
  );
};

export default UserCard;
