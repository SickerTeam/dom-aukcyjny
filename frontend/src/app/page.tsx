'use client'

import Image from 'next/image'
import { Main,CustomButton,Artworks } from '../../components'
import ArtworkCard from '../../components/ArtworkCard';

const popularArtworks = [
  {title: "Mona Lisa by Leonardo da Vinci(1503-1506)", price: "1,300,000", time: 2},
  {title: "Starry Night by Vincent van Gogh(1889)", price: "12,000,000", time: 2},
  {title: "The Persistence of Memory by Salvador Dalí (1931)", price: "4,200,000", time: 2},
  {title: "The Scream by Edvard Munch (1893)", price: "8,500,000", time: 2},
];

export default function Home() {
  const handleScroll = () => {

  }
  return (
    <main className="overflow-hidden">
    <Main/>
      
  
      <div className="padding-x padding-y mt-10">
          <h1 className='font-bold'>Buy or bid on over 2,137 objects every week, created by 420+ artists</h1>
          <div className="gap-4 mt-10">
            <h1 className='font-bold'>Registracio Registracio</h1>
            <p>he is a good zong frfr</p>
          </div>
        </div>
        <div className='discovery w-full'>
          <div className='padding-x padding-y mt-10'>
            <h1 className='font-bold text-white'>Your daily discovery</h1>
            <p className=' text-white'>Log in and explore Zongers to get personalised finds.Updated daily.</p>
            <CustomButton
             title="Discover all"
             containerStyles="bg-white text-black rounded-full mt-10"
             handleClick={handleScroll}
             /> 
          </div>
          </div>
          <div className='w-full justify-between'>
            <div className='padding-x padding-y mt-10'>
              <h1 className='font-bold text-black mb-4'>Popular paintings</h1>
              <div className='grid grid-cols-3 gap-4 mb-4'>
                {popularArtworks.map((artwork, index) => (
                  <ArtworkCard key={index} artwork={artwork} /> 
                ))}

              </div>
              

            </div>
          </div>
    </main>
  );
}
