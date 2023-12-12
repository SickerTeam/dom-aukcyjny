import React from 'react'

const EditProfile = () => {
  return (
    <div className='flex'>
      <div className="sidebar  text-black h-full w-1/5 p-4">
        <ul>
          <li className="mb-2"><a href="/yourprofile">My Profile</a></li>
          <li className="mb-2"><a href="/yourprofile/addresses">Addresses</a></li>
          <li className="mb-2"><a href="/yourprofile/payments">Payments</a></li>
          <li className="mb-2"><a href="/yourprofile/myfavourites">My favourites</a></li>
        </ul>
      </div>

    <div className='p-4 mx-auto w-4/5'>
      <h2 className="text-2xl font-bold mb-4">Settings</h2>
      
      <div className="mb-4 border-2 border-solid rounded-md border-gray-300 w-3/6">
        <div className='flex flex-col '>
        <label className="text-lg font-semibold  ml-2">First name</label>
        <div className='flex justify-between'>
        <p className="text-sm  ml-2">
          Test
        </p>
        <button className='border-2 w-1/6 border-black '>Edit</button>
        </div>
        </div>
        <div className='flex flex-col'>
        <label className="text-lg font-semibold  ml-2">E-mail</label>
        <div className='flex justify-between'>
        <p className="text-sm ml-2">
          test@example.com
        </p>
        <button className='border-2 w-1/6 border-black'>Edit</button>
        </div>
        </div>
        <div className='flex flex-col'>
        <label className="text-lg font-semibold  ml-2">Password</label>
        <div className='flex justify-between'>
        <p className="text-sm ml-2 ">
          test@example.com
        </p>
        <button className='border-2 w-1/6 border-black'>Edit</button>
        </div>
        </div>
      </div>
    </div>
    </div>
  )
}

export default EditProfile