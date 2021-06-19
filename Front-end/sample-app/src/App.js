import React from 'react'
import './App.css'
import { Switch, Route } from 'react-router-dom'
import FrontPage from './components/front page/frontPage'
import EventPage from './components/event page/eventPage'
import TestPage from './components/test page/testPage'
import CoursePage from './components/courses page/coursesPage'
import SignIn from './components/forms/signIn'
import SignUp from './components/forms/signUp'
// import Api from './components/api/api'

function App() {

  return (
    <>
      <Switch>
        <Route exact path="/">
          <FrontPage />
        </Route>
        <Route exact path='/courses'>
          <CoursePage />
        </Route>
        <Route exact path='/signUp'>
          <SignUp />
        </Route>
        <Route exact path='/events'>
          <EventPage />
        </Route>
        <Route exact path='/testPage'>
          <TestPage />
        </Route>
      </Switch>

      {/* <Api /> */}

      {/* <FrontPage /> */}
      {/* <EventPage /> */}
      {/* <CoursePage /> */}
      {/* <TestPage /> */}
      {/* <SignUp /> */}
    </>
  )
}

export default App

