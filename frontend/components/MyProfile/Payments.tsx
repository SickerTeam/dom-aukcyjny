const MyPayments = () => {
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
      </div>
  )
}

export default MyPayments