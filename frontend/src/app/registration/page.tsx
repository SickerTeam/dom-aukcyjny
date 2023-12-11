'use client'

import React, { ChangeEvent, useState } from 'react';
import RegistrationPage from '../../../components/RegistrationPage';

const Registration = () => {
  const [formData, setFormData] = useState({
    email: '',
    password: '',
    firstName: '',
    lastName: '',
    bio: '',
    country: ','

  });

  const handleChange = (e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
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
