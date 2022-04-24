import axios, { AxiosInstance } from "axios";

export const instance: AxiosInstance = axios.create({
  baseURL: process.env.REACT_APP_API_URL,
  headers: { ApiKey: process.env.REACT_APP_API_KEY || "" },
});
