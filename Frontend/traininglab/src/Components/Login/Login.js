import React, { useState } from "react";
import { Link, useHistory, useLocation } from "react-router-dom"; //eslint-disable-line
import { useSelector, useDispatch } from "react-redux";
import { login } from "../../actions/auth";

const Login = (props) => {
  const [username, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [formErrors, setFormErrors] = useState({ err: "" });
  const [submitLoading, setSubmitLoading] = useState(false);

  var { isLoggedIn } = useSelector((state) => state.auth);
  const { message } = useSelector((state) => state.message);

  const dispatch = useDispatch();

  const handleChangeUserName = (event) => {
    setUserName(event.target.value);
  };

  const handleChangePassword = (event) => {
    setPassword(event.target.value);
  };

  const handleFormValidation = () => {
    let formErrors = {};
    let formIsValid = true;

    if (!username) {
      formIsValid = false;
      formErrors["userNameErr"] = "Username is required.";
    } else if (!username.trim()) {
      formIsValid = false;
      formErrors["userNameErr"] = "Username is required";
    }

    if (!password) {
      formIsValid = false;
      formErrors["passwordErr"] = "Password is required";
    } else if (password.length < 8) {
      formIsValid = false;
      formErrors["passwordErr"] = "Password needs to be 8 characters or more";
    }

    setFormErrors({ err: formErrors });
    return formIsValid;
  };

  let history = useHistory();
  //let location = useLocation();

  //let { from } = location.state || { from: { pathname: "/" } };

  const handleSubmit = async (event) => {
    //eslint-disable-line
    event.preventDefault();
    setSubmitLoading(true);

    if (handleFormValidation()) {
      await dispatch(login(username, password))
        .then(() => {
          setSubmitLoading(true);
        })
        .catch((err) => {
          console.log("error from login", err);
          setSubmitLoading(true);
        });
    } else {
      setSubmitLoading(false);
    }
    if (!isLoggedIn) {
      history.push("/home");
    }
  };
  
  return (
    <div className="font-myfonts form1-content-right bg-customwhite">
      <button className="facebook-button sc-dnqmqq iTCbCQ">
        <svg
          width="20"
          height="20"
          viewBox="0 0 20 20"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            fillRule="evenodd"
            clipRule="evenodd"
            d="M20 10.0611C20 4.50451 15.5229 0 10 0C4.47715 0 0 4.50451 0 10.0611C0 15.0829 3.65686 19.2452 8.4375 20V12.9694H5.89844V10.0611H8.4375V7.84452C8.4375 5.32296 9.93043 3.93012 12.2146 3.93012C13.3087 3.93012 14.4531 4.12663 14.4531 4.12663V6.60261H13.1921C11.9499 6.60261 11.5625 7.37816 11.5625 8.17381V10.0611H14.3359L13.8926 12.9694H11.5625V20C16.3431 19.2452 20 15.0829 20 10.0611Z"
            fill="#1877F2"
          ></path>
        </svg>
        <span className="text">Continue with Facebook</span>
      </button>

      <button className="google-button sc-gqjmRU cnCRxi">
        <svg
          width="18"
          height="18"
          viewBox="0 0 18 18"
          fill="none"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            fillRule="evenodd"
            clipRule="evenodd"
            d="M17.64 9.20443C17.64 8.56625 17.5827 7.95262 17.4764 7.36353H9V10.8449H13.8436C13.635 11.9699 13.0009 12.9231 12.0477 13.5613V15.8194H14.9564C16.6582 14.2526 17.64 11.9453 17.64 9.20443Z"
            fill="#4285F4"
          ></path>
          <path
            fillRule="evenodd"
            clipRule="evenodd"
            d="M8.99976 18C11.4298 18 13.467 17.1941 14.9561 15.8195L12.0475 13.5613C11.2416 14.1013 10.2107 14.4204 8.99976 14.4204C6.65567 14.4204 4.67158 12.8372 3.96385 10.71H0.957031V13.0418C2.43794 15.9831 5.48158 18 8.99976 18Z"
            fill="#34A853"
          ></path>
          <path
            fillRule="evenodd"
            clipRule="evenodd"
            d="M3.96409 10.7101C3.78409 10.1701 3.68182 9.59325 3.68182 9.00007C3.68182 8.40689 3.78409 7.83007 3.96409 7.29007V4.95825H0.957273C0.347727 6.17325 0 7.5478 0 9.00007C0 10.4523 0.347727 11.8269 0.957273 13.0419L3.96409 10.7101Z"
            fill="#FBBC05"
          ></path>
          <path
            fillRule="evenodd"
            clipRule="evenodd"
            d="M8.99976 3.57955C10.3211 3.57955 11.5075 4.03364 12.4402 4.92545L15.0216 2.34409C13.4629 0.891818 11.4257 0 8.99976 0C5.48158 0 2.43794 2.01682 0.957031 4.95818L3.96385 7.29C4.67158 5.16273 6.65567 3.57955 8.99976 3.57955Z"
            fill="#EA4335"
          ></path>
        </svg>
        <span className="text">Continue with Google</span>
      </button>

      <div className="form-seperator-1">
        <p>or</p>
      </div>

      <form
        className="mt-16 h-2/3 w-full flex flex-col justify-center items-center p-4"
        noValidate
      >
        <div className="font-myfonts text-sm">
          <label className="inline-block mb-2 text-customblack">Username</label>
          <input
            className="outline-none mx-auto my-auto block w-72 bg-customwhite border-2 border-solid border-customblack box-border"
            type="text"
            name="userName"
            value={username}
            onChange={handleChangeUserName}
          />
          {(formErrors.err.userNameErr && (
            <p className="text-red-600">{formErrors.err.userNameErr}</p>
          )) ||
            (message && <p className="text-red-600">{message}</p>)}
        </div>
        <div className="font-myfonts mt-2 text-sm">
          <label className="inline-block mb-2 text-customblack">Password</label>
          <input
            className="mx-auto my-auto block w-72 bg-customwhite border-2 border-customblack box-border"
            type="password"
            name="password"
            value={password}
            onChange={handleChangePassword}
          />
          {(formErrors.err.passwordErr && (
            <p className="text-red-600">{formErrors.err.passwordErr}</p>
          )) ||
            (message && <p className="text-red-600">{message}</p>)}
        </div>
        <button
          style={{background:"#FFC107",color:"#171E27"}}
          className="cursor-pointer font-myfonts mx-auto text-lg w-1/3 h-12 mt-8 border-2 outline-none border-none  text-center "
          type="submit"
          onClick={handleSubmit}
          disabled={submitLoading}
        >
          {submitLoading && (
            <div className="flex flex-row">
              <svg
                xmlns="https://www.w3.org/2000/svg"
                className="animate-spin h-6 w-6 ml-2"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  strokeWidth={2}
                  d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15"
                />
              </svg>
              {console.log("Loading State:", submitLoading)}
              <div className="ml-4 my-2"> Verifying...</div>
            </div>
          )}
          {!submitLoading && <div className="my-2">Login</div>}
        </button>
        <div className="text-sm mt-3 text-center w-4/5 text-customblack">
          Not a member..? {" "}
          <Link to="/signup" className="text-blue-600">
            Sign Up
          </Link>
        </div>
      </form>
    </div>
  );
};

export default Login;
