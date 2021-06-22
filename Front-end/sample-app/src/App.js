import React from 'react'
import './App.css'
import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom";
import FrontPage from './components/front page/frontPage'
import EventPage from './components/event page/eventPage'
import TestPage from './components/test page/testPage'
import CoursePage from './components/courses page/coursesPage'
import SignIn from './components/forms/signIn'
import SignUp from './components/forms/signUp'
// <<<<<<< HEAD
// import Api from './components/api/api'
// import Youtube from './components/react-youtube/reactYoutube'
// =======
import ReactPage from './components/courses page/react';
import Angular from './components/courses page/Angular';
import Csharp from './components/courses page/Csharp';
import Node from './components/courses page/Node';
import Blender from './components/courses page/Blender'


function App() {

  return (
    <>


      <Switch>
        <Route exact path="/" component={FrontPage} />
        <Route exact path="/signin" component={SignIn} />
        <Route exact path="/signup" component={SignUp} />
        <Route exact path="/courses" component={CoursePage} />
        <Route exact path="/events" component={EventPage} />
        <Route exact path="/test" component={TestPage} />
        <Route exact path='/courses/react' component={ReactPage} />
        <Route exacr path='/signIn' component={SignIn} />


        <Router>
          <Switch>
            <Route exact path="/" component={FrontPage} />
            <Route exact path="/signin" component={SignIn} />
            <Route exact path="/signup" component={SignUp} />
            <Route exact path="/courses" component={CoursePage} />
            <Route exact path="/events" component={EventPage} />
            <Route exact path="/test" component={TestPage} />
            <Route exact path='/courses/react' component={ReactPage} />
            <Route exact path='/courses/angular' component={Angular} />
            <Route exact path='/courses/csharp' component={Csharp} />
            <Route exact path='/courses/node' component={Node} />
            <Route exact path='/courses/blender' component={Blender} />
          </Switch>
        </Router>
      </Switch>


    </>
  )
}

export default App

