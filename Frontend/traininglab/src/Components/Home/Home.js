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

const Home = () => {
  return (
    <Router>
      <Switch>
        <Route exact path="/">
          <Landing></Landing>
        </Route>
        <Route path="/home">
          <Starter></Starter>
        </Route>
        <Route path="/events">
          <Events></Events>
        </Route>
        <Route path="/tests">
          <Test></Test>
        </Route>
        <Route path="/net">
          <Net></Net>
        </Route>
        <Route path="/visual">
          <Visual></Visual>
        </Route>
        <Route path="/react">
          <ReactDeveloper></ReactDeveloper>
        </Route>
        <Route path="*">
          <Nomatch />
        </Route>
      </Switch>
    </Router>
  );
};

export default Home;
