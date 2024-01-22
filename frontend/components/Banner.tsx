import Image from "next/image";

const Banner = () => {
  return (
    <div className="flex justify-between h-[700px] bg-main-green shadow-md p-20">
      <div className="m-auto w-fit gap-4 self-center">
        <h1 className="w-auto text-3xl text-white">
          Sell something <span className="italic text-light-gray">cool</span> or
          not cool idgaf
        </h1>
        <p className="w-80 pb-6 text-darker-white">
          Lorem ipsum dolor. Minus quas, officiis itaque voluptatibus cupiditate
          modi amet.
        </p>
        <button
          type="button"
          className="bg-light-gray italic text-black text-xl py-2 w-full rounded shadow-sm"
        >
          <h2 className="w-full">
            <a href="/lots" className="block w-full">
              Sell stuff
            </a>
          </h2>
        </button>
      </div>
      {/* <div>
        <Image src="/../../corpoboi.jpg" alt="Post Image" fill={true} />
      </div> */}
    </div>
  );
};

export default Banner;
