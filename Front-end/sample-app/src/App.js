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
<<<<<<< HEAD
import Api from './components/api/api'
import Youtube from './components/react-youtube/reactYoutube'
=======
import ReactPage from './components/courses page/react';
// import Api from './components/api/api'
>>>>>>> ada56f9285446993261a090c9bbdb5da630c130f

function App() {

  return (
    <>
    <Router>
    <Switch>
    <Route exact path = "/" component = {FrontPage} />
      <Route exact path = "/signin" component = {SignIn} />
      <Route exact path = "/signup" component = {SignUp} />
      <Route exact path = "/courses" component = {CoursePage} />
      <Route exact path = "/events" component = {EventPage} />
      <Route exact path = "/test" component = {TestPage} />
      <Route exact path = '/courses/react' component = {ReactPage} />

          {/* <Route path="/">
            <About />
          </Route>
          <Route path="/topics">
            <Topics />
          </Route>
          <Route path="/">
            <Home />
          </Route> */}
        </Switch>
    </Router>


      {/* <Youtube /> */}

      {/* <Api /> */}

<<<<<<< HEAD
=======
      {/* <FrontPage /> */}
      {/* <EventPage /> */}
      {/* <CoursePage /> */}
      {/* <TestPage /> */}
      {/* <SignUp /> */}

>>>>>>> ada56f9285446993261a090c9bbdb5da630c130f
    </>
  )
}

export default App

