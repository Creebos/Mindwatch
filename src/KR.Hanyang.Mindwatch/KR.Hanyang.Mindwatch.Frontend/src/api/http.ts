import axios from "axios";

const apiClient = axios.create({
  baseURL: "https://localhost:8081/api", // Backend API URL
  timeout: 10000,
  headers: {
    "Content-Type": "application/json",
  },
});

export default apiClient;
