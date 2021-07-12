import React from "react";
import { Route } from "react-router";
import { Link } from "react-router-dom";
import { useDispatch } from "react-redux";
import { logout } from "../../actions/auth";
import { logoutOnRefreshFail } from "../../actions/auth";
import axios from "axios";

const API = "https://localhost:44388/api/";


const Navigation =  () => {
  var currentUser = JSON.parse(localStorage.getItem("user"));
  const dispatch = useDispatch();

  //var data = useSelector((state)=>state.auth)
   // let navAuth = data?.state?.isLoggedIn;
    //console.log(navAuth);

  const authrize_access = async(history,url) => {
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
        dispatch(logoutOnRefreshFail());
        history.push("/login");
        console.log("Error in refreshing: ", error);
      });

        console.log("Error in refreshing: ", error);
      }
    });
    };

  const logOut = async () => {
    await dispatch(logout());
    window.location = "/login";
  };

  const bgStyle = {
    backgroundColor: "#171E27",
    padding:"10px 0"
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
    padding: ".5rem 1rem",
    // border:"2px solid #FFC107",
    // borderRadius: "10px 0 10px 0",
    marginRight:"10px",
    color:"#FFC107"
  }

  const user = {
    display: "block",
    padding: "1rem 1rem 1rem 1rem",
  }
  return (
    <div style={bgStyle}>
      <ul style={ulStyle} className="p-1">
       

        {currentUser ? (
          <div className="flex flex-row">
             <Route
          render={({ history }) => (
            <li onClick={() =>{authrize_access(history,"/home")}} style={navItem}>
              <Link style={pos} className="cursor-pointer font-myfonts border-none  text-center " aria-current="page">
                Home
              </Link>
            </li>
          )}
        />

        <Route
          render={({ history }) => (
            <li onClick={() => {authrize_access(history,"/events")}} style={navItem}>
              <Link style={pos} className="cursor-pointer font-myfonts border-none  text-center ">
                Events
              </Link>
            </li>
          )}
        />
        <Route
          render={({ history }) => (
            <li onClick={() => {authrize_access(history,"/tests")}} style={navItem}>
              <Link style={pos} className="cursor-pointer font-myfonts border-none  text-center ">
                Tests
              </Link>
            </li>
          )}
        />

        <Route
          render={({ history }) => (
            <li onClick={() => {authrize_access(history,"/motivational")}} style={navItem}>
              <Link style={pos} className="cursor-pointer font-myfonts   text-center ">Courses</Link>
            </li>
          )}
        />
            <li style={pos}><Link  className="cursor-pointer font-myfonts text-center ">Welcome, {currentUser.username}</Link></li>
            <li onClick={logOut} style={navItem} ><Link style={pos} className="cursor-pointer font-myfonts border-none  text-center ">Log Out</Link></li>
          </div>

          
        ) : (
          <div className="flex flex-row">
            <Route
              render={({ history }) => (
                <li onClick={() => history.push("/signup")} style={navItem}>
                  <Link style={pos} className="cursor-pointer font-myfonts border-none  text-center " to="/signup">
                    Sign Up
                  </Link>
                </li>
              )}
            />
            <Route
              render={({ history }) => (
                <li onClick={() => history.push("/login")} style={navItem}>
                  <Link style={pos} className="cursor-pointer font-myfonts border-none  text-center " to="/login">
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
