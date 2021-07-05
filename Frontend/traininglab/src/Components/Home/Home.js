import React from "react";
import Landing from "../Landing/Landing";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Starter from "../Landing/Starter";
import Nomatch from "../Nomatch/Nomatch";
import Net from "../Courses/Net/Net";
import Visual from "../Courses/Visual/Visual";
import ReactDeveloper from "../Courses/ReactDeveloper/ReactDeveloper";
import Events from "../Events/Events";
import Test from "../Test/Test";
import LoginPage from "../LoginPage";
import SignupPage from "../SignupPage";
import Motivational from "../Courses/Motivational/Motivational"
import PrivateRoute from "../PrivateRoute/PrivateRoute"
const Home = () => {
  return (
    <Router>
      <Switch>
        <Route exact path="/"  component={Landing} />
        
        <Route path="/login" component={LoginPage} />
        <Route path="/signup" component={SignupPage} />

        <PrivateRoute path="/home">
          <Starter></Starter>
        </PrivateRoute>
        <PrivateRoute path="/events">
          <Events></Events>
        </PrivateRoute>
        <PrivateRoute path="/tests">
          <Test></Test>
        </PrivateRoute>
        <PrivateRoute path="/net">
          <Net></Net>
        </PrivateRoute>
        <PrivateRoute path="/visual">
          <Visual></Visual>
        </PrivateRoute>
        <PrivateRoute path="/react">
          <ReactDeveloper></ReactDeveloper>
        </PrivateRoute>
        <PrivateRoute path="/motivational">
          <Motivational></Motivational>
        </PrivateRoute>
        {/* <PrivateRoute path="/home" component={Starter} />
        <PrivateRoute path="/events" component={Events} />
        <PrivateRoute path="/tests" component={Test} />
        <PrivateRoute path="/net" component={Net} />
        <PrivateRoute path="/visual" component={Visual} />
        <PrivateRoute path="/react" component={ReactDeveloper} />
        <PrivateRoute path="/motivational" component={Motivational} /> */}
        <Route path="*" component={Nomatch} />
      </Switch>
    </Router>
  );
};

export default Home;
