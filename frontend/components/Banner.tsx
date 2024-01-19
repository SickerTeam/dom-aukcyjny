import Image from "next/image";


const Banner = () => {

  return (
    <div className="grid grid-cols-3 grid-rows-1 gap-4 h-[700px] bg-main-green shadow-md  ">
      <div className="w-fit self-center mx-2">
        <h1 className="w-auto text-3xl text-white">
          We connect{" "}
          <span className="italic text-light-gray">Artists</span> and
          <span className="italic text-light-gray">Art lovers</span> 
        </h1>
        <p className="w-80 pb-6 text-darker-white">
          We don't make mistakes, just happy little accidents. -Bob Ross
        </p>
        <button
          type="button"
          className="bg-light-gray italic text-black text-xl py-2 w-full rounded shadow-sm"
        >
          <h2>Start browsing</h2>
        </button>
      </div>

      <div className="self-center col-span-2  h-3/5">
        <Image 
          src="/../main.png"
          alt="Zong logo"
          className="object-fill  rounded-md"
          width={650}
          height={500}>

        </Image>
      </div>
    </div>
  );
};

export default Banner;
