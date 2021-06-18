import React from "react";
import Signup from "./Signup/Signup";
import Navigation from "./Landing/Navigation";

const SignupPage = () => {
  return (
    <div className="bg-customwhite">
      <Navigation />
      <div className="form-container">
        <span className="close-btn">×</span>
        <div className="font-myfonts form-content-left bg-customnewblue">
          <h2 className="font-myfonts mt-12 text-customblack">
            Join Training Lab for Free
          </h2>
          <h4 className="font-myfonts mt-12 text-customblack">
            Begin Your Journey
          </h4>
          <div className="seperator"></div>
        </div>
        <Signup />
      </div>
    </div>
  );
};

export default SignupPage;
