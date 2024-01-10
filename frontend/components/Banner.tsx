const Banner = () => {
  return (
    <div className="grid grid-cols-3 grid-rows-1 gap-4 h-[700px] bg-main-green shadow-md  ">
      <div className="w-fit self-center">
        <h1 className="w-auto text-3xl text-white">
          Here put some{" "}
          <span className="italic text-light-gray">cool main</span> text
        </h1>
        <p className="w-80 pb-6 text-darker-white">
          Lorem ipsum dolor. Minus quas, officiis itaque voluptatibus cupiditate
          modi amet.
        </p>
        <button
          type="button"
          className="bg-light-gray italic text-black text-xl py-2 w-full rounded shadow-sm"
        >
          <h2>Cool button</h2>
        </button>
      </div>

      <div className="self-center col-span-2 bg-light-gray h-3/5">picture</div>
    </div>
  );
};

export default Banner;
