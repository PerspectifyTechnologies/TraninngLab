import React from "react";
import Login from "./Login/Login";
import Navigation from "./Landing/Navigation";

const LoginPage = () => {
  return (
    <div className="bg-customwhite">
      <Navigation />
      <div className="form1-container">
        <div className="form1-content-left bg-customnewblue text-customblack">
          <h2 className="font-myfonts text-customblack">
            Welcome Back to Training Lab
          </h2>
          <h4 className="font-myfonts text-customblack">
            Sign In to continue to your Account
          </h4>
          <div className="seperator"></div>
        </div>
        <Login />
      </div>
    </div>
  );
};
export default LoginPage;
