import React from "react";
import { Route } from "react-router-dom";

const Landing = () => {
  return (
    <div className="mainDiv">
      <div>
        <div className="flex justify-center items-center h-screen text-black">
          <div className="text-center">
            <h1 className="text-perFont font-normal text-perColor pb-2">
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
                  <div className="flex flex-row text-labFont bg-labColor rounded-imgRadius w-1/3 p-training cursor-pointer hover:bg-white">
                    <span className="ml-8 mr-4">Training Lab</span>
                    <span>
                      <svg
                        xmlns="http://www.w3.org/2000/svg"
                        fill="currentColor"
                        className="mt-3 w-6 h-6 bi bi-arrow-right-circle-fill"
                        viewBox="0 0 16 16"
                      >
                        <path d="M8 0a8 8 0 1 1 0 16A8 8 0 0 1 8 0zM4.5 7.5a.5.5 0 0 0 0 1h5.793l-2.147 2.146a.5.5 0 0 0 .708.708l3-3a.5.5 0 0 0 0-.708l-3-3a.5.5 0 1 0-.708.708L10.293 7.5H4.5z" />
                      </svg>
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
