import React from "react";
import { Route } from "react-router";
import { Link } from "react-router-dom";

const Navigation = () => {
  return (
    <div className="bg-navBackground">
      <ul className="flex flex-row flex-wrap pl-0 mb-0 justify-center list-none p-10">
        <Route
          render={({ history }) => (
            <li onClick={() => history.push("/home")} className="text-center">
              <Link
                to="/home"
                className="my-4 ml-4 mr-4 text-white block p-4 no-underline cursor-pointer"
                aria-current="page"
              >
                Home
              </Link>
            </li>
          )}
        />

        <Route
          render={({ history }) => (
            <li onClick={() => history.push("/events")} className="text-center">
              <Link
                to="/events"
                className="my-4 mx-4 text-white block p-4 no-underline cursor-pointer"
              >
                Events
              </Link>
            </li>
          )}
        />
        <Route
          render={({ history }) => (
            <li onClick={() => history.push("/tests")} className="text-center">
              <Link
                to="/tests"
                className="my-4 mx-4 text-white block no-underline cursor-pointer"
              >
                Tests
              </Link>
            </li>
          )}
        />
        <button className="text-white my-4 mx-4 rounded-full ">Sign Up</button>
        <button className="text-white my-4 mx-4 rounded-full ">Login</button>
      </ul>
    </div>
  );
};

export default Navigation;
