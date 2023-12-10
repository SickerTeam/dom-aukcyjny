const isProduction = process.env.NODE_ENV === "production";
const baseUrl = isProduction
  ? process.env.NEXT_PUBLIC_REACT_APP_API_PROD_URL
  : process.env.NEXT_PUBLIC_REACT_APP_API_BASE_URL;

const apiService = {
  get: async (endpoint, options = {}) => {
    const response = await fetch(`${baseUrl}${endpoint}`, options);
    return response.json();
  },

  post: async (endpoint, data, options = {}) => {
    const response = await fetch(`${baseUrl}${endpoint}`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        ...options.headers,
      },
      body: JSON.stringify(data),
      ...options,
    });

    return response.json();
  },

  // Add other HTTP methods as needed
};

export default apiService;
