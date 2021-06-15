import React from "react";
import { Route } from "react-router";
import Navigation from "./Navigation";
import cNetImage from "../../assets/cnet.svg";
import visualImage from "../../assets/visual.jpg";
import reactImage from "../../assets/react.png";

const Starter = () => {
  return (
    <div>
      <div>
        <Navigation />
      </div>
      <div className="starterBg h-starterHeight">
        <div className="flex justify-evenly items-center h-trialHeight">
          <Route
            render={({ history }) => (
              <div
                onClick={() => history.push("/net")}
                className="flex flex-row justify-center w-1/4 bg-imgColor rounded-imgRadius h-imgHeight"
              >
                <img
                  className="max-w-full h-auto w-1/4 cursor-pointer"
                  src={cNetImage}
                  alt=""
                />
              </div>
            )}
          />

          <Route
            render={({ history }) => (
              <div
                onClick={() => history.push("/visual")}
                className="flex flex-row justify-center w-1/4 bg-imgColor rounded-imgRadius h-imgHeight"
              >
                <img
                  className="my-12 max-w-full h-auto w-1/2 cursor-pointer"
                  src={visualImage}
                  alt=""
                />
              </div>
            )}
          />

          <Route
            render={({ history }) => (
              <div
                onClick={() => history.push("/react")}
                className="flex flex-row justify-center w-1/4 bg-imgColor rounded-imgRadius h-imgHeight"
              >
                <img
                  className="my-10 max-w-full h-auto w-1/2 cursor-pointer"
                  src={reactImage}
                  alt=""
                />
              </div>
            )}
          />
        </div>
      </div>
    </div>
  );
};

export default Starter;
