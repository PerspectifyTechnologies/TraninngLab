import React from "react";
import { Route } from "react-router";
import { Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { logout } from "../../actions/auth";

const Navigation = () => {
  const { user: currentUser } = useSelector((state) => state.auth);
  const dispatch = useDispatch();

  const logOut = () => {
    dispatch(logout());
    alert("Logged out successfully.");
    window.location='/home'
  };

  return (
    <div className="bg-navBackground">
      <ul className="flex flex-row flex-wrap pl-0 mb-0 justify-center list-none p-10">
        <Route
          render={({ history }) => (
            <li onClick={() => history.push("/home")} className="text-center">
              <Link
                to="/home"
                className="my-6 ml-4 mr-4 text-white block p-4 no-underline cursor-pointer"
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
                className="my-6 mx-4 text-white block p-4 no-underline cursor-pointer"
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
                className="my-6 mx-4 text-white block no-underline cursor-pointer"
              >
                Tests
              </Link>
            </li>
          )}
        />

        <Route render={({history})=>(
                    <li onClick={()=> history.push('/motivational')} className="text-center">
                        <Link  className="my-6 mx-4 text-white block no-underline cursor-pointer" >Usefull_Resource</Link>
                    </li>
                )} />

        {currentUser ? (
          <div className="flex flex-row">
            <li className="text-center">{currentUser.username}</li>
            <Route
              render={() => (
                <li
                  onClick={logOut}
                  className="text-center my-6 mx-4 text-white block no-underline cursor-pointer"
                >
                  Log Out
                </li>
              )}
            />
          </div>
        ) : (
          <div className="flex flex-row">
            <Route
              render={({ history }) => (
                <li
                  onClick={() => history.push("/signup")}
                  className="text-center"
                >
                  <Link
                    to="/signup"
                    className="my-6 mx-4 text-white block no-underline cursor-pointer"
                  >
                    Sign Up
                  </Link>
                </li>
              )}
            />
            <Route
              render={({ history }) => (
                <li
                  onClick={() => history.push("/login")}
                  className="text-center"
                >
                  <Link
                    to="/login"
                    className="my-6 mx-4 text-white block no-underline cursor-pointer"
                  >
                    Login
                  </Link>
                </li>
              )}
            />
          </div>
        )}
      </ul>
    </div>
  );
};

export default Navigation;
