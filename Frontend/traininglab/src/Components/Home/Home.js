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
import ProfilePage from "../profile/ProfilePage";
import Motivational from "../Courses/Motivational/Motivational"
import PrivateRoute from "../PrivateRoute/PrivateRoute"
import PrivateLoginRoute from "../PrivateRoute/PrivateLoginRoute"
const Home = () => {
  return (
    <Router>
      <Switch>
        <Route exact path="/"  component={Landing} />
        <PrivateLoginRoute path="/login"><LoginPage></LoginPage></PrivateLoginRoute>
        <PrivateLoginRoute path="/signup"><SignupPage></SignupPage></PrivateLoginRoute>

        <PrivateRoute path="/ProfilePage">
          <ProfilePage></ProfilePage>
        </PrivateRoute>
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
        <Route path="*" component={Nomatch} />
      </Switch>
    </Router>
  );
};

export default Home;
