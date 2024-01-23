'use client'

import React, { ChangeEvent, useState } from 'react';
import RegistrationPage from '../../../components/RegistrationPage';

const Registration = () => {

  const [formData, setFormData] = useState({
    email: '',
    password: '',
    confirmPassword: '',
    firstName: '',
    lastName: '',
    bio: '',
    country: '',
    personalLink: '',
    profilePictureLink: '',
    role: 0
  });

  const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  }; 


  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

        await fetch('http://localhost:5156/user', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
      });

  };




  return (
    <div className="flex items-center justify-center">
      <RegistrationPage
        formData={formData}
        handleChange={handleChange}
        handleSubmit={handleSubmit}

      />
    </div>
  );
};

export default Registration;
