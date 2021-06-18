// Authentication-service
//The service uses Axios for HTTP requests and Local Storage for user information & JWT.
/*It provides following important functions:
register(): POST {username, email, password}
login(): POST {username, password} & save JWT to Local Storage
logout(): remove JWT from Local Storage*/

import axios from "axios";

const API = "";

const register = async (username, email, password) => {
  const signup_data = {
    username: username,
    email: email,
    password: password,
  };
  return await axios.post(API + "signup", signup_data);
};

const login = async (username, password) => {
  const signin_data = {
    username: username,
    password: password,
  };
  return await axios
    .post(API + "signin", signin_data)
    .then((res) => {
      console.log(res.data);
      if (res.data.accesToken) {
        localStorage.setItem("user", JSON.stringify(res.data));
      }
      return res.data;
    })
    .catch((err) => {
      console.log("Error in login: ", err);
    });
};

const logout = () => {
  localStorage.removeItem("user");
};

export default { register, login, logout }; //eslint-disable-line
