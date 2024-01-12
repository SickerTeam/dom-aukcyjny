export default function SideNavigation(){
  return (
    <div className="fixed top-21 h-screen  p-4">
      <div className="mb-4">
        <button className="flex items-center space-x-2 p-2 rounded-md bg-white hover:bg-gray-300">
          <img src="/../../home.svg" alt="Home Icon" className="w-6 h-6" />
          <span>Home</span>
        </button>
      </div>

      <div className="mb-4">
        <button className="flex items-center space-x-2 p-2 rounded-md bg-white hover:bg-gray-300">
          <img src="/../../search.svg" alt="Search Icon" className="w-6 h-6" />
          <span>Search</span>
        </button>
      </div>
      <div className="mb-4">
        <button className="flex items-center space-x-2 p-2 rounded-md bg-white hover:bg-gray-300">
          <img src="/../../notification.svg" alt="Notifications Icon" className="w-6 h-6" />
          <span>Notifications</span>
        </button>
      </div>
      <div className="mb-4">
        <button className="flex items-center space-x-2 p-2 rounded-md bg-white hover:bg-gray-300">
          <img src="/../../saved.svg" alt="saved Icon" className="w-6 h-6" />
          <span>Saved</span>
        </button>
      </div>      
    </div>
  );
};


