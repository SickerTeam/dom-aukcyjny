import Link from "next/link"

const MyProfile = () => {
    return (
      <div className="max-w-5xl mx-auto p-4">
    <h2 className="text-2xl font-bold mb-4">My profile</h2>
    <p>Welcome back, bro! </p>
    <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4 mt-5">
      <div className="bg-white p-4 rounded shadow-md">
        <Link href="/yourprofile/edit">
        <h3 className="text-lg font-semibold mb-2">Settings</h3>
        <p className="text-gray-600">Configure your account settings.</p>
        </Link>
      </div>
      <div className="bg-white p-4 rounded shadow-md">
        <h3 className="text-lg font-semibold mb-2">Addresses</h3>
        <p className="text-gray-600">Manage your shipping addresses.</p>
      </div>
      <div className="bg-white p-4 rounded shadow-md">
        <h3 className="text-lg font-semibold mb-2">Payments</h3>
        <p className="text-gray-600">View and update payment methods.</p>
      </div>
      <div className="bg-white p-4 rounded shadow-md">
        <h3 className="text-lg font-semibold mb-2">My favourites</h3>
        <p className="text-gray-600">Preview your saved arts.</p>
      </div>
      <div className="bg-white p-4 rounded shadow-md">
        <h3 className="text-lg font-semibold mb-2">Logout</h3>
        <p className="text-gray-600">Log out of your profile.</p>
      </div>
    </div>
  </div>
  
    )
  }
  
  export default MyProfile