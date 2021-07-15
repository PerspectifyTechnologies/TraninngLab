import React, { useEffect, useState } from 'react';
import styles from './reactdevelop.module.css'
import ReactPlayer from "react-player";
import Navigation from '../../Landing/Navigation';

const ReactDeveloper = () => {

    const [videoUrl, setVideoUrl] = useState("\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/01.ReactJS_Tutorial_-_1_-_Introduction.mp4\n");

  

const [reactData, setReactData] = useState([]);
useEffect(() => {
  fetch(
    "https://localhost:44388/api/QueryCourses/SubCourses?SubCourseID=2"
  )
    .then((res) => res.json())
    .then((data) => {
      console.log("newdata",data);
      setReactData(data)
    });
}, []);

  
 
  const [linkInfo,setLinkInfo] = useState({
    courseID: 1,
    name: "An Introduction to C# learning cycle.",
    url: "https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/01.An_Introduction_To_The_C%23_Learning_Cycle.mp4",
    subCourseID: 1,
    title: "An Introduction to C# learning cycle.",
    desc: "Desc",
  })
  const handleUrl = (id) => {
    const linkData = reactData.find((item) => item.subCourseID === id && item);
    setLinkInfo(linkData);
    const link = linkData?.url;
    setVideoUrl(link);
  };
    
      

  const listStyle = {
    background: "#171E27",
    color: "#FFC107",
    margin: "7px",
    padding: "10px",
    width: "30vw",
    borderRadius: "10px",
  };

  return (
    <div style={{ height: "100%" }} className={styles.starterBg}>
            <div>
              <Navigation></Navigation>
            </div>
            <div className="grid grid-cols-5 gap-4">
                
                <div
                style={{ height: "90vh" }}
                className="flex justify-center items-center col-span-3 "
                >
                    <div>
                    <div style={{color:"#FFC107"}} className="my-5 text-center transparentCard  p-5">
              <p className=" font-bold">{linkInfo.title}</p>
            </div>
                <ReactPlayer controls url={videoUrl} />
                    </div>
                </div>
                <div className="flex justify-center items-center col-span-2">
                    <div style={{height:"33rem"}} className="  overflow-auto rounded-2xl">
                        <div style={{padding: "1.75rem"}} className="p-7 transparentCard">
                            {
                                reactData.map(item => <p style={listStyle} className="cursor-pointer" onClick={()=>handleUrl(item.subCourseID)}>{item.name}</p> )
                            }
                        </div>
                    </div>
                </div>
        </div>
    </div>
  );
};

export default ReactDeveloper;