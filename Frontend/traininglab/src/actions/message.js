//This Redux action creator is for actions related to messages (notifications) from APIs.

import * as types from "./types";

export const setMessage = (message) => ({
  type: types.SET_MESSAGE,
  payload: message,
});

export const clearMessage = () => ({
  type: types.CLEAR_MESSAGE,
});
