import { useSelector } from "react-redux";
import { Route,Redirect } from "react-router";





function PrivateRoute({ children, ...rest }) {
    //let auth = useAuth();
    var LoggedIn;
    if ("user" in localStorage) {
      LoggedIn = true;
  } else {
    LoggedIn = false;
  }
    var data = useSelector((state)=>state.auth)
    let auth = data?.state;
    console.log(LoggedIn);
    return (
      <Route
        {...rest}
        render={({ location }) =>
          LoggedIn ? (
            children
          ) : (
            <Redirect
              to={{
                pathname: "/login",
                state: { from: location }
              }}
            />
          )
        }
      />
    );
  }

  export default PrivateRoute;