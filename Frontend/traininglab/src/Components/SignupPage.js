import React from "react";
import Signup from "./Signup/Signup";
import Navigation from "./Landing/Navigation";

const SignupPage = () => {
  return (
    <div>
      <div>
        <Navigation />
      </div>
        <div style={{height:"110vh"}} className="starterBg">
        
        <div style={{paddingTop:"25px"}}>
          <div style={{marginTop:"0",marginBottom:"0"}} className="form-container">
            <span className="close-btn">×</span>
            <div style={{background:"#171E27",color:"#FFC107"}} className="font-myfonts form-content-left ">
              <h2 className="font-myfonts mt-12 ">
                Join Training Lab for Free
              </h2>
              <h4 className="font-myfonts mt-12 ">
                Begin Your Journey
              </h4>
              <div></div>
            </div>
            <Signup />
          </div>
        </div>
      </div>
    </div>
  );
};

export default SignupPage;
