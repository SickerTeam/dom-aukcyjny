"use client";

import Image from 'next/image'
import { CustomButton } from '.'

const Main = () => {
    const handleScroll = () => {

    }
  return (
    <div className='main'>
     <div className='flex-1 pt-36 padding-x'>
        <h1 className='main__title'>
            Bringing online auctions to a next level!
        </h1>

        <p className="main__subtitle">
            Elevate your auction experience with Zong.
        </p>

           <CustomButton
             title="Explore auctions"
             containerStyles="bg-primary-blue text-white rounded-full mt-10"
             handleClick={handleScroll}
             /> 
        </div>    
    </div>
  )
}

export default Main