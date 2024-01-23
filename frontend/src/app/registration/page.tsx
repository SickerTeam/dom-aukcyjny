"use client";

import React, { ChangeEvent, useState } from "react";
import apiService from "../../../services/apiService";

const Registration = () => {
  const [formData, setFormData] = useState({
    email: "",
    password: "",
    confirmPassword: "",
    firstName: "",
    lastName: "",
    bio: "",
    country: "",
    personalLink: "",
    imageLink: "",
  });

  const handleChange = (
    e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    apiService.register(formData);
  };

  return (
    <div className="flex items-center justify-center">
      {/* <RegistrationPage
        formData={formData}
        handleChange={handleChange}
        handleSubmit={handleSubmit}
      /> */}
    </div>
  );
};

export default Registration;
