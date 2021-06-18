/*Because we only have a single store in a Redux application, we have used reducer composition 
instead of many stores to split data handling logic.*/

import { combineReducers } from 'redux'
import userReducer from './auth'
import messageReducer from './message'

const rootReducer = combineReducers({
    auth: userReducer,
    message: messageReducer
})

export default rootReducer