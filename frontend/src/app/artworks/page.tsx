import Image from 'next/image'
import { Artworks, Filters } from '../../../components'

export default function ArtworksList() {

  const artworks =  Array.from({ length: 100 }, (_, index) => ({
    title: `Mona Lisa by Leonardo da Vinci (1503 - 1506)`,
    price: 1300000, // You can modify this if you want random prices
    time: 10, // You can modify this if you want random times
  }));
  
  return (
    <main className='overflow-hidden'>
      <Filters />

      <Artworks artworks={artworks}/>
    </main>
  )
}
