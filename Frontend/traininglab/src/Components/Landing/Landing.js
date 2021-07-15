import React from "react";
import { Route } from "react-router-dom";

const Landing = () => {
  return (
    <div className="mainDiv">
      <div>
        <div className="flex justify-center items-center h-screen text-black">
          <div className="text-center">
            <h1 className="text-landingh font-normal text-landingh1 pb-mybottom">
              Perspectify
            </h1>
            <Route
              render={({ history }) => (
                <div
                  onClick={() => {
                    history.push("/home");
                  }}
                  className="flex justify-center items-center my-12"
                >
                  <div className="p-px text-landingp border-2 border-solid border-white w-1/5 flex items-center justify-evenly hover:bg-black hover:text-white">
                    <span
                      className="cursor-pointer"
                      style={{ padding: "0", marginBottom: "0" }}
                    >
                      Let's go
                    </span>
                  </div>
                </div>
              )}
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Landing;
