"use client";

import { CustomButton } from ".";

const Main = () => {
  return (
    <div className="main">
      <div className="flex-1 pt-36">
        <h1 className="main__title">
          Bringing online auctions to a next level!
        </h1>
        
         <p className="">
            Elevate your auction experience with Zong.
        </p>

        <CustomButton
          title="Explore auctions"
          containerStyles="bg-primary-blue text-white rounded-full mt-10"
          handleClick={() => console.log("Yooooo")}
        />
      </div>
    </div>
  );
};

export default Main;
