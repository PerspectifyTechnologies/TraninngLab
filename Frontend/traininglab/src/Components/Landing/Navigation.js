import React from "react";
import { Route } from "react-router";
import { Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { logout } from "../../actions/auth";
import axios from "axios";

const API = "https://localhost:44388/api/";



const Navigation = () => {
  const { user: currentUser } = useSelector((state) => state.auth);
  const dispatch = useDispatch();

  const authrize_access = (history,url) => {
    var token = JSON.parse(localStorage.getItem("user"));
    var axiosConfig = {
    headers : {
      'Authorization' : "bearer "+token.jwtToken
    }
    };
    axios.get(API+"auth",axiosConfig)
    .then((res) => {
      history.push(url);
    })
    .catch((error) => {
      if(error.response.status === 401){
        var postData = {
        token: token.jwtToken
      };
      axios.post(API + "refresh", postData)
      .then((res2) => {
          localStorage.removeItem("user");
          localStorage.setItem("user", JSON.stringify(res2.data));
          history.push(url);
      })
      .catch((error) =>{
        alert("Session Expired Login Again.");
        dispatch(logout());
        history.push("/login");
        console.log("Error in refreshing: ", error);
      });

        console.log("Error in refreshing: ", error);
      }
    });
    };
  const logOut = () => {
    dispatch(logout());
    window.location = "/login";
  };

  const bgStyle = {
    backgroundColor: "#02111B",
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

  const pos = {
    display: "block",
    padding: "1rem 1rem",
  }

<<<<<<< HEAD
  

=======
  const user = {
    display: "block",
    padding: "1rem 1rem 1rem 1rem",
  }
>>>>>>> aa9767e234833bcbb9b03eab5d779e533f4ad2df
  return (
    <div style={bgStyle}>
      <ul style={ulStyle} className="p-1">
       

        {currentUser ? (
          <div className="flex flex-row">
             <Route
          render={({ history }) => (
            <li onClick={() =>{authrize_access(history,"/home")}} style={navItem}>
              <Link style={pos} className="cursor-pointer font-myfonts border-none bg-customblack hover:bg-customnewblue text-customnewblue hover:text-customblack text-center " aria-current="page">
                Home
              </Link>
            </li>
          )}
        />

        <Route
          render={({ history }) => (
            <li onClick={() => {authrize_access(history,"/events")}} style={navItem}>
              <Link style={pos} className="cursor-pointer font-myfonts border-none bg-customblack hover:bg-customnewblue text-customnewblue hover:text-customblack text-center ">
                Events
              </Link>
            </li>
          )}
        />
        <Route
          render={({ history }) => (
            <li onClick={() => {authrize_access(history,"/tests")}} style={navItem}>
              <Link style={pos} className="cursor-pointer font-myfonts border-none bg-customblack hover:bg-customnewblue text-customnewblue hover:text-customblack text-center ">
                Tests
              </Link>
            </li>
          )}
        />

        <Route
          render={({ history }) => (
            <li onClick={() => {authrize_access(history,"/motivational")}} style={navItem}>
              <Link style={pos} className="cursor-pointer font-myfonts border-none bg-customblack hover:bg-customnewblue text-customnewblue hover:text-customblack text-center ">Courses</Link>
            </li>
          )}
        />
            <li style={navItem}><Link style={user} className="cursor-pointer font-myfonts border-none bg-customblack  text-customnewblue text-center ">Welcome, {currentUser.username}</Link></li>
            <li onClick={logOut} style={navItem} ><Link style={pos} className="cursor-pointer font-myfonts border-none bg-customblack hover:bg-customnewblue text-customnewblue hover:text-customblack text-center ">Log Out</Link></li>
          </div>

          
        ) : (
          <div className="flex flex-row">
            <Route
              render={({ history }) => (
                <li onClick={() => history.push("/signup")} style={navItem}>
                  <Link style={pos} className="cursor-pointer font-myfonts border-none bg-customblack hover:bg-customnewblue text-customnewblue hover:text-customblack text-center " to="/signup">
                    Sign Up
                  </Link>
                </li>
              )}
            />
            <Route
              render={({ history }) => (
                <li onClick={() => history.push("/login")} style={navItem}>
                  <Link style={pos} className="cursor-pointer font-myfonts border-none bg-customblack hover:bg-customnewblue text-customnewblue hover:text-customblack text-center " to="/login">
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
