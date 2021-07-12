//This reducer updates message state when message action is dispatched from anywhere in the application.
import * as types from "../actions/types";

const initialState = {};

const messageReducer = (state = initialState, action) => {
  switch (action.type) {
    case types.SET_MESSAGE:
      return {
        ...state,
        message: action.payload,
      };

    case types.CLEAR_MESSAGE:
      return {
        ...state,
        message: "",
      };

    default:
      return state;
  }
};

export default messageReducer;
