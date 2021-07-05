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
    window.location = "/home";
  };

  const bgStyle = {
    backgroundColor: "#332155",
  };
  const ulStyle = {
    display: "flex",
    flexWrap: "wrap",
    paddingLeft: "0",
    marginBottom: "0",
    listStyle: "none",
    justifyContent: "center",
  };
  const navItem = {
    textAlign: "center",
  };

  const navLink = {
    color: "white",
    display: "block",
    padding: "1rem 1rem",
    textDecoration: "none",
    color: "#f7fbfc",
  };

  return (
    <div style={bgStyle}>
      <ul style={ulStyle} className="p-1">
        <Route
          render={({ history }) => (
            <li onClick={() => history.push("/home")} style={navItem}>
              <Link style={navLink} to="/home" aria-current="page">
                Home
              </Link>
            </li>
          )}
        />

        <Route
          render={({ history }) => (
            <li onClick={() => history.push("/events")} style={navItem}>
              <Link style={navLink} to="/events">
                Events
              </Link>
            </li>
          )}
        />
        <Route
          render={({ history }) => (
            <li onClick={() => history.push("/tests")} style={navItem}>
              <Link style={navLink} to="/tests">
                Tests
              </Link>
            </li>
          )}
        />

        <Route
          render={({ history }) => (
            <li onClick={() => history.push("/motivational")} style={navItem}>
              <Link style={navLink}>Courses</Link>
            </li>
          )}
        />

        {currentUser ? (
          <div className="flex flex-row">
            <li style={navItem}>{currentUser.username}</li>
            <Route render={() => <li onClick={logOut}>Log Out</li>} />
          </div>

          
        ) : (
          <div className="flex flex-row">
            <Route
              render={({ history }) => (
                <li onClick={() => history.push("/signup")} style={navItem}>
                  <Link style={navLink} to="/signup">
                    Sign Up
                  </Link>
                </li>
              )}
            />
            <Route
              render={({ history }) => (
                <li onClick={() => history.push("/login")} style={navItem}>
                  <Link style={navLink} to="/login">
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
