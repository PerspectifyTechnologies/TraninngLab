import * as types from "../actions/types";

const user = localStorage.getItem("user");

const initialState = user
  ? { isLoggedIn: true, user }
  : { isLoggedIn: false, user: null };

const userReducer = (state = initialState, action) => {
  switch (action.type) {
    case types.SIGNUP_SUCCESS:
      return {
        ...state,
        isLoggedIn: false,
      };
    case types.SIGNUP_FAIL:
      return {
        ...state,
        isLoggedIn: false,
      };
    case types.LOGIN_SUCCESS:
      return {
        ...state,
        isLoggedIn: true,
        user: action.payload.user,
      };
    case types.LOGIN_FAIL:
      return {
        ...state,
        isLoggedIn: false,
        user: null,
      };
    case types.LOGOUT:
      return {
        ...state,
        isLoggedIn: false,
        user: null,
      };
    default:
      return {
        state,
      };
  }
};

export default userReducer;
