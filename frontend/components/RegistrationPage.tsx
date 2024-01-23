import React, { ChangeEvent } from "react";

type RegistrationPageProps = {
  formData: {
    email: string;
    password: string;
    confirmPassword: string;
    firstName: string;
    lastName: string;
    bio: string;
    country: string;
    personalLink: string;
    imageLink: string;
  };
  handleChange: (
    e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => void;
  handleSubmit: (e: React.FormEvent<HTMLFormElement>) => void;
};

const RegistrationPage: React.FC<RegistrationPageProps> = ({
  formData,
  handleChange,
  handleSubmit,
}) => {
  const { v4: uuidv4 } = require("uuid");

  const handleFileUpload = async (event: any) => {
    console.log("we should be uploading");
    const file = event.target.files[0];
    const fileName = `${uuidv4()}`;
    const accessUrl = `https://zongbucket.s3.eu-north-1.amazonaws.com/Users/${fileName}`;
    const uploadResponse = await fetch(
      `https://localhost:5156/Amazon?key=Users/${fileName}`
    );
    if (uploadResponse.ok && file) {
      const link = await uploadResponse.text();
      const data = new FormData();
      data.append("file", file, file.name);
      const fileUpload = await fetch(link, {
        method: "PUT",
        headers: {
          "Content-Type": "image/jpeg",
        },
        body: file,
      }).catch((error) => {
        console.error("Failed to upload picture:", error);
      });
    }

    console.log(accessUrl);
    formData.profilePictureLink = accessUrl;

    handleSubmit;
  };

  return (
    <form
      onSubmit={handleSubmit}
      className="bg-white px-8 pt-6 pb-8 mb-4 w-full max-w-md"
    >
      <h2 className="text-2xl font-bold mb-4 text-center">Register</h2>
      <div className="mb-4">
        <label
          className="block text-gray-700 text-sm font-bold mb-2"
          htmlFor="email"
        >
          Email:
        </label>
        <input
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="email"
          type="email"
          name="email"
          value={formData.email}
          onChange={handleChange}
          placeholder="Enter your email"
        />
      </div>
      <div className="mb-4">
        <label
          className="block text-gray-700 text-sm font-bold mb-2"
          htmlFor="password"
        >
          Password:
        </label>
        <input
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="password"
          type="password"
          name="password"
          value={formData.password}
          onChange={handleChange}
          placeholder="Enter your password"
        />
      </div>
      <div className="mb-4">
        <label
          className="block text-gray-700 text-sm font-bold mb-2"
          htmlFor="confirmPassword"
        >
          Confirm Password:
        </label>
        <input
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="confirmPassword"
          type="password"
          name="confirmPassword"
          value={formData.confirmPassword}
          onChange={handleChange}
          placeholder="Confirm your password"
        />
      </div>
      <div className="mb-4">
        <label
          className="block text-gray-700 text-sm font-bold mb-2"
          htmlFor="firstName"
        >
          First Name:
        </label>
        <input
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="firstName"
          type="text"
          name="firstName"
          value={formData.firstName}
          onChange={handleChange}
          placeholder="Enter your first name"
        />
      </div>
      <div className="mb-4">
        <label
          className="block text-gray-700 text-sm font-bold mb-2"
          htmlFor="lastName"
        >
          Last Name:
        </label>
        <input
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="lastName"
          type="text"
          name="lastName"
          value={formData.lastName}
          onChange={handleChange}
          placeholder="Enter your last name"
        />
      </div>
      <div className="mb-4">
        <label
          className="block text-gray-700 text-sm font-bold mb-2"
          htmlFor="bio"
        >
          Bio:
        </label>
        <textarea
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="bio"
          name="bio"
          value={formData.bio}
          onChange={handleChange}
          placeholder="Enter your bio"
        />
      </div>
      <div className="mb-4">
        <label
          className="block text-gray-700 text-sm font-bold mb-2"
          htmlFor="country"
        >
          Country:
        </label>
        <input
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="country"
          type="text"
          name="country"
          value={formData.country}
          onChange={handleChange}
          placeholder="Enter your country"
        />
      </div>
      <div className="mb-4">
        <label
          className="block text-gray-700 text-sm font-bold mb-2"
          htmlFor="personalLink"
        >
          Personal link :
        </label>
        <input
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="personalLink"
          type="text"
          name="personalLink"
          value={formData.personalLink}
          onChange={handleChange}
          placeholder="Enter your personal link"
        />
      </div>
      <div className="mb-4">
        <label
          className="block text-gray-700 text-sm font-bold mb-2"
          htmlFor="profilePictureLink"
        >
          Profile picture:
        </label>
        <input
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          id="imageLink"
          type="text"
          name="imageLink"
          value={formData.imageLink}
          onChange={handleChange}
          placeholder="Enter your profile picture link"
        />
      </div>
      <div className="flex items-center justify-end">
        <button
          className="bg-black text-white w-full py-2 px-4 rounded focus:outline-none focus:shadow-outline mx-auto block"
          type="submit"
          onClick={handleFileUpload}
        >
          Register
        </button>
      </div>
    </form>
  );
};

export default RegistrationPage;
