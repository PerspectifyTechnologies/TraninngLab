// This service is for accessing data

import axios from "axios";
import authHeader from "./auth-header";

const API = "";

const getPublicContent = () => {
  return axios.get(API + "all");
};

const getCourses = () => {
  return axios.get(API + "courses", { headers: authHeader() });
};

const getUserDetails = () => {
  return axios.get(API + "user", { headers: authHeader() });
};

export default { getPublicContent, getCourses, getUserDetails };
