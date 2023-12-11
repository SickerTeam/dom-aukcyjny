'use client'

import React, { ChangeEvent, useState } from 'react';
import LoginPage from '../../../components/LoginPage';
import Link from 'next/link';

const Login = () => {
  const [formData, setFormData] = useState({
    email: '',
    password: '',
  });

  const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log('Form submitted:', formData);
    // Add your registration logic here
  };

  return (
    <div className="flex items-center justify-center w-400px h-200">
      <div className="flex-1 mx-4">
        <LoginPage
          formData={formData}
          handleChange={handleChange}
          handleSubmit={handleSubmit}
        />
      </div>
      <div className="mb-4 flex-1 ">
        <h2 className="text-2xl font-bold mb-4">Register</h2>
        <p>You don`t have an account? Create one! </p>
        <Link href="/registration">
        <button
          className="bg-black text-white  py-2 px-4 rounded focus:outline-none focus:shadow-outline ml-10"
          type="button"
        >
          Register
        </button>
        </Link>
      </div>
    </div>
   );
  };

export default Login;
