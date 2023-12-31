const Navigation = () => {
  return (
    <div className="fixed top-0 h-screen bg-gray-200 p-4">
  <div className="mb-4">
    <button className="flex items-center space-x-2 p-2 rounded-md bg-white hover:bg-gray-300">
      <img src="/../../like.ico" alt="Home Icon" className="w-6 h-6" />
      <span>Home</span>
    </button>
  </div>


  <div className="mb-4">
    <button className="flex items-center space-x-2 p-2 rounded-md bg-white hover:bg-gray-300">
      <img src="/../../like.ico" alt="Search Icon" className="w-6 h-6" />
      <span>Search</span>
    </button>
  </div>


  <div className="mb-4">
    <button className="flex items-center space-x-2 p-2 rounded-md bg-white hover:bg-gray-300">
      <img src="/../../like.ico" alt="Notifications Icon" className="w-6 h-6" />
      <span>Notifications</span>
    </button>
  </div>


  <div>
    <button className="flex items-center space-x-2 p-2 rounded-md bg-white hover:bg-gray-300">
      <img src="/../../like.ico" alt="Saved Icon" className="w-6 h-6" />
      <span>Saved</span>
    </button>
  </div>
</div>

  );
};

export default Navigation;
