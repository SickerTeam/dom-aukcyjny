import Image from 'next/image'
import { Footer, Main, Navbar } from '../../components'

export default function Home() {
  return (
    <main className='overflow-hidden'>
      <Navbar/>
      <Main/>
      <Footer/>
    </main>
  )
}
