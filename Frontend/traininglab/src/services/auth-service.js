// Authentication-service
//The service uses Axios for HTTP requests and Local Storage for user information & JWT.
/*It provides following important functions:
register(): POST {username, email, password}
login(): POST {username, password} & save JWT to Local Storage
logout(): remove JWT from Local Storage*/

import axios from "axios";

const API = "https://localhost:44388/api/";

const register = async (username, email, password) => {
  const signup_data = {
    username: username,
    email: email,
    password: password,
  };
  return await axios.post(API + "register", signup_data);
};

const login = async (username, password) => {
  const signin_data = {
    username: username,
    password: password,
  };
  return await axios
    .post(API + "login", signin_data)
    .then((res) => {
       if (res.data.jwtToken) {
         localStorage.setItem("user", JSON.stringify(res.data));
       }
      return res.data;
    })
    .catch((err) => {
      console.log("Error in login: ", err);
    });
};

const logout = async() => {
  var token = JSON.parse(localStorage.getItem("user"));
  console.log(token);
  localStorage.removeItem("user");
  var postData = {
    username: token.username,
    token : "bearer "+token.jwtToken
    }
   await axios.post(API +"logout", postData)
  .then((res) => {
    console.log(res);
  })
  .catch((err) => {
    console.log("Error in login: ", err);
  });
};

export default { register, login, logout }; //eslint-disable-line
