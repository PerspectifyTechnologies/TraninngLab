import { Route, Redirect } from "react-router";

function PrivateLoginRoute({ children, ...rest }) {
  var LoggedIn;
  if ("user" in localStorage) {
    LoggedIn = true;
  } else {
    LoggedIn = false;
  }

  return (
    <Route
      {...rest}
      render={({ location }) =>
        !LoggedIn ? (
          children
        ) : (
          <Redirect
            to={{
              pathname: "/home",
              state: { from: location },
            }}
          />
        )
      }
    />
  );
}

export default PrivateLoginRoute;
