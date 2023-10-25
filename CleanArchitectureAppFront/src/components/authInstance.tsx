import axios from 'axios';

const authInstance = axios.create();

authInstance.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token');
    console.log("token: "+token);
    if (token) {
      config.headers.Authorization = `bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

export default authInstance;