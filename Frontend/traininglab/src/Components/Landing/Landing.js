import React from "react";
import styles from "./Landing.module.css";
import { Route } from "react-router-dom";

const Landing = () => {
  const headingStyle = {
    fontSize: "10vw",
    fontWeight: "400",
    color: "#f7fbfc",
    paddingBottom: "10px",
  };
  const pStyle = {
    fontSize: "2vw",
    border: "2px solid white",
    padding: "1px",
    width: "20%",
  };

  const flexStyle = {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    height: "100vh",
    color: "black",
  };

  return (
    <div className={styles.mainDiv}>
      <div>
        <div style={flexStyle}>
          <div style={{ textAlign: "center" }}>
            <h1 style={headingStyle}>Perspectify</h1>

            <Route
              render={({ history }) => (
                <div
                  onClick={() => {
                    history.push("/home");
                  }}
                  style={{
                    display: "flex",
                    justifyContent: "center",
                    alignItems: "center",
                    marginTop: "3rem",
                    marginBottom: "3rem",
                  }}
                >
                  <div
                    className="flex items-center justify-evenly "
                    style={pStyle}
                >
                    <span className='cursor-pointer ' style={{ padding: "0", marginBottom: "0" }}>
                      Let's go
                    </span>
                  </div>
                </div>
              )}
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Landing;
