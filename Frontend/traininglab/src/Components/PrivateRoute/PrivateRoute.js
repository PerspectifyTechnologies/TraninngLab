import { useSelector } from "react-redux";
import { Route,Redirect } from "react-router";





function PrivateRoute({ children, ...rest }) {
    //let auth = useAuth();
    const data = useSelector((state)=>state.auth)
    let auth = data?.state;
    console.log(auth);
    return (
      <Route
        {...rest}
        render={({ location }) =>
          auth.isLoggedIn ? (
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