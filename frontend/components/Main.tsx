const Main = () => {
  return (
    <div className="main">
      {/* wrap this div in a component like banner or wahtever u want to call it */}
      <div className="grid grid-cols-4 grid-rows-3 gap-4 h-[500px]">
        <div className="col-span-2 row-span-2 place-self-end">
          <h1 className="w-auto bg-gray-300 text-3xl">
            Here put some{" "}
            <span className="italic text-main-green">cool main</span> text...
          </h1>
        </div>
        <div className="col-start-1 row-start-3">
          <div className="col-span-2 row-span-2">
            <h1 className="w-auto bg-gray-300">
              Bringing online auctions to a next leve
            </h1>
          </div>
        </div>
        <div className="col-span-2 row-span-3 col-start-3 row-start-1">
          <div className="col-span-2 row-span-2">
            <div className="w-full h-full bg-gray-300">asd</div>
          </div>
        </div>
      </div>
      <div></div>
    </div>
  );
};

export default Main;
