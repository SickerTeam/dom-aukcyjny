// set the base display of 10 pictures before having to click show more, if less than 10 uploaded - show all

type PhotoDisplayType = {
  photos: number[];
};

const PhotoDisplay = ({ photos }: PhotoDisplayType) => {
  return (
    <div className="grid grid-cols-2 grid-rows-7 gap-4">
      <div className="col-span-2 bg-blue-400">1</div>
      <div className="row-start-2 bg-blue-400">2</div>
      <div className="row-start-2 bg-blue-400">3</div>
      <div className="col-span-2 row-start-3 bg-blue-400">4</div>
      <div className="row-start-4 bg-blue-400">5</div>
      <div className="row-start-4 bg-blue-400">6</div>
      <div className="col-span-2 row-start-5 bg-blue-400">7</div>
      <div className="row-start-6 bg-blue-400">8</div>
      <div className="row-start-6 bg-blue-400">9</div>
      <div className="col-span-2 row-start-7 bg-blue-400">10</div>
    </div>
  );
};

export default PhotoDisplay;
