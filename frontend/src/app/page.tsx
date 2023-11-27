'use client'

import Image from 'next/image'
import { Main,CustomButton } from '../../components'

export default function Home() {
  const handleScroll = () => {

  }
  return (
    <main className="overflow-hidden">
    <Main/>
      
  
      <div className="padding-x padding-y mt-10">
          <h1 className='font-bold'>Buy or bid on over 2,137 objects every week, created by 420+ artists</h1>
          <div className="grid grid-cols-5 gap-4 mt-10">
            <h1>Gosho</h1>
            <p>he is a good zong frfr</p>
          </div>
        </div>
        <div className='discovery w-full'>
          <div className='padding-x padding-y mt-10'>
            <h1 className='font-bold text-white'>Your daily discovery</h1>
            <p className='flex-col items-center text-white'>Log in and explore Zongers to get personalised finds.Updated daily.</p>
            <CustomButton
             title="Discover all"
             containerStyles="bg-white text-black rounded-full mt-10"
             handleClick={handleScroll}
             /> 
          </div>
          </div>
          <div className='w-full '>
            <div className='padding-x padding-y mt-10'>
              <h1 className='font-bold text-black'>Popular paintings</h1>
              

            </div>
          </div>
    </main>
  );
}
