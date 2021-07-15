import React, { useEffect, useState } from "react";
import Navigation from "../Landing/Navigation";
import styles from "../Landing/starter.module.css";
import userimage from "../../assets/userimage.jpg";
const ProfilePage = () => {
  const [newData, setNewData] = useState([]);

  useEffect(() => {
    var currentUser = JSON.parse(localStorage.getItem("user"));
    fetch("https://localhost:44388/api/userprofile/" + currentUser.username)
      .then((res) => res.json())
      .then((data) => {
        setNewData(JSON.parse(data));
      });
  }, [newData]);

  var curr = newData;
  const imgFlex = {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    width: "50%",
    height: "50%",
    borderRadius: "10px",
  };

  const infoStyle = {
    fontfamily: "sans-serif",
    justifyContent: "center",
    background: "#FFC107",
    color: "black",
    padding: "10px 70px",
    margin: "5px",
    borderRadius: "20px",
    display: "flex",
  };
  const starterStyle = {
    height: "90vh",
  };
  return (
    <div>
      <Navigation></Navigation>
      <div style={starterStyle} class={styles.starterBg}>
        <div
          style={{
            height: "90vh",
            display: "flex",
            justifyContent: "space-evenly",
            alignItems: "center",
          }}
        >
          <div
            className={styles.transparentCard}
            style={{ height: "20vh", width: "20vh", borderRadius: "10px" }}
          >
            <img
              style={{ borderRadius: "85px" }}
              src={userimage}
              alt="Profile"
            />
          </div>
          <div style={imgFlex} className={styles.transparentCard}>
            {
              <div>
                <div style={infoStyle}>username : {curr.Username}</div>
                <div style={infoStyle}>score : {curr.Score}</div>
                <div style={infoStyle}>level : {curr.Level}</div>
              </div>
            }
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProfilePage;
