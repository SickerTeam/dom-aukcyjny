import React, { ChangeEvent } from 'react';

type LoginPageProps = {
  formData: { email: string; password: string };
  handleChange: (e: ChangeEvent<HTMLInputElement>) => void;
  handleSubmit: (e: React.FormEvent<HTMLFormElement>) => void;
};

const LoginPage: React.FC<LoginPageProps> = ({
  formData,
  handleChange,
  handleSubmit,
}) => {
  return (
    <form onSubmit={handleSubmit} className="bg-white px-8 pt-6 pb-8 mb-4 w-full max-w-md">
      <h2 className="text-2xl font-bold mb-4">Enter your profile</h2>
      <div className="mb-4">
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="email">
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
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
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
      <div className="flex items-center justify-end">
        <button
          className="bg-black text-white w-full py-2 px-4 rounded focus:outline-none focus:shadow-outline mx-auto block"
          type="submit"
        >
          Login
        </button>
      </div>
    </form>
  );
};

export default LoginPage;
