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

const Home = () => {
  return (
    <Router>
      <Switch>
        <Route path="/" exact component={Landing} />
        <Route path="/home" component={Starter} />
        <Route path="/login" component={LoginPage} />
        <Route path="/signup" component={SignupPage} />
        <Route path="/events" component={Events} />
        <Route path="/tests" component={Test} />
        <Route path="/net" component={Net} />
        <Route path="/visual" component={Visual} />
        <Route path="/react" component={ReactDeveloper} />
        <Route path="*" component={Nomatch} />
      </Switch>
    </Router>
  );
};

export default Home;
