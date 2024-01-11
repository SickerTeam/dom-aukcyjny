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

  login: async (credentials) => {
    const response = await apiService.post(
      "/authentication/login",
      credentials
    );

    // If login is successful, store the token in localStorage
    if (response.token) {
      localStorage.setItem("token", response.token);
    }

    return response;
  },

  register: async (userData) => {
    const response = await apiService.post(
      "/authentication/register",
      userData
    );

    // If registration is successful, store the token in localStorage
    if (response.token) {
      localStorage.setItem("token", response.token);
    }

    return response;
  },

  getUserInfo: async () => {
    const token = localStorage.getItem("token");

    if (!token) {
      return null; // No token, no user info
    }

    const response = await apiService.get("/users/info", {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });

    return response;
  },

  // Add other HTTP methods as needed
};

export default apiService;
