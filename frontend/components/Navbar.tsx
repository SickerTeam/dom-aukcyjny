import Link from 'next/link';
import Image from 'next/image';
import { CustomButton } from '.';

const Navbar = () => {

  return (
    <header className="w-full absolute z-10">
      <nav className="flex justify-between items-center">
        <Link href="/" className='flex justify-center items-center ml-8'>
          <Image src="/logo.svg" alt='Zong logo' width={118} height={18} className='object-contain'/>
        </Link>
        <div className="flex ml-20">
          <input className="w-96 h-8 border-2 border-black rounded-full text-center" type="text" placeholder='Search by title,artist or category...'></input>
            </div>
            <div className='flex'>
              <CustomButton title="Sell" btnType="button" containerStyles='sellBtn font-bold'/>
              <CustomButton title="Pricing" btnType="button" containerStyles='text-primary-black font-bold'/>
              <CustomButton title="Help" btnType="button" containerStyles='text-primary-black font-bold'/>
              <CustomButton title="Log in" btnType="button" containerStyles='text-primary-black font-bold'/>
        </div>
      </nav>
    </header>
  )
}

export default Navbar