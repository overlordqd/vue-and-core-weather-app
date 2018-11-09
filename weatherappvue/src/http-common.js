import axios from 'axios';

export const HTTP = axios.create({
  baseURL: 'http://localhost:5000/api'
})

HTTP.interceptors.response.use((response) => {
  return response;
}, function (error) {
  if (error.response.status === 400) {
      window.console.log(error.response.data);
  }
  return Promise.reject(error.response);
});