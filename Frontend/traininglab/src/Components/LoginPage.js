import React from "react";
import Login from "./Login/Login";
import Navigation from "./Landing/Navigation";

const LoginPage = () => {
  return (
    <div>
      <div>
      <Navigation />
      </div>
      <div style={{height:"90vh"}} className="starterBg">
      
      <div style={{paddingTop:"25px"}}>
          <div style={{marginTop:"0",marginBottom:"0"}} className="form1-container">
            <div style={{background:"#171E27",color:"#FFC107"}} className="form1-content-left  ">
              <h2 className="font-myfonts ">
                Welcome Back to Training Lab
              </h2>
              <h4 className="font-myfonts ">
                Sign In to continue to your Account
              </h4>
              <div ></div>
            </div>
              <Login />
          </div>
      </div>
    </div>
    </div>
  );
};
export default LoginPage;
