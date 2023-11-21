import Image from 'next/image'
import { Main, Navbar } from '../../components'

export default function Home() {
  return (
    <main className='overflow-hidden'>
      <Navbar/>
      <Main/>
    </main>
  )
}
