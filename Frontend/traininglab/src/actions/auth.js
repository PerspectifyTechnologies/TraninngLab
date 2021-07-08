//This is creator for actions related to authentication.
//We have imported AuthService to make asynchronous HTTP requests with trigger one or more dispatch in the result.

import * as types from "./types";
import AuthService from "../services/auth-service";

export const register = (username, email, password) => async (dispatch) => {
  return AuthService.register(username, email, password).then(
    (response) => {
      dispatch({ type: types.SIGNUP_SUCCESS });
      dispatch({ type: types.SET_MESSAGE, payload: response.data.message });
      return Promise.resolve();
    },
    (error) => {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();
      dispatch({ type: types.SIGNUP_FAIL });
      dispatch({ type: types.SET_MESSAGE, payload: message });
      return Promise.reject();
    }
  );
};

export const login = (username, password) => async (dispatch) => {
  return AuthService.login(username, password).then(
    (data) => {
      dispatch({ type: types.LOGIN_SUCCESS, payload: { user: data } });
      return Promise.resolve();
    },
    (error) => {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();
      dispatch({ type: types.LOGIN_FAIL });
      dispatch({ type: types.SET_MESSAGE, payload: message });
      return Promise.reject();
    }
  );
};

export const logout = () => async(dispatch) => {
  AuthService.logout();
  dispatch({ type: types.LOGOUT });
};
export const logoutOnRefreshFail = () => async (dispatch) => {
  localStorage.removeItem("user");
  dispatch({ type: types.LOGOUT });
};