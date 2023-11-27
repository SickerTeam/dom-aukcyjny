import Link from "next/link";

const Footer = () => {
  return (
    <footer className='footer w-full flex flex-wrap justify-between mt-10 border-t'>
      <div className='flex-col flex ml-5 items-center py-10'>
        <p className='font-bold pb-5'>Random stuff</p>
        <Link href="/">
          idk
        </Link>
      </div>

      <div className='flex-col flex items-center py-10'>
        <p className='font-bold pb-5'>Company</p>
        <Link href="/" className="mb-2">
          Careers
        </Link>
        <Link href="/" className="mb-2">
          Privacy policy
        </Link>
        <Link href="/" className="mb-2">
          Terms of service
        </Link>
      </div>

      <div className='flex-col flex items-center py-10'>
        <p className='font-bold pb-5'>Support</p>
        <Link href="/" className="mb-2">
          Help
        </Link>
        <Link href="/" className="mb-2">
          Plans and price
        </Link>
        <Link href="/" className="mb-2">
          Upcoming stuff
        </Link>
      </div>

      <div className='flex-col flex mr-5 items-center py-10'>
        <p className='font-bold pb-5'>Follow us</p>
        <Link href="/" className="mb-2">
          Facebook
        </Link>
        <Link href="/" className="mb-2">
          Instagram
        </Link>
        <Link href="/" className="mb-2">
          Twitter
        </Link>
      </div> 
    </footer>
  );
};

export default Footer;
