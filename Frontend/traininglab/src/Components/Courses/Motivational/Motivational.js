import React, { useState } from 'react';
import styles from '../../Landing/starter.module.css'
import ReactPlayer from "react-player";
import motivationalData from './motivationalData';
import styles1 from './Motivational.module.css';
import Navigation from '../../Landing/Navigation'

const Motivational = () => {


    
    
      const [videoUrl, setVideoUrl] = useState("https://www.youtube.com/watch?v=t1XCzWlYWeA")


      const [linkInfo, setLinkInfo] = useState({
        courseID: 1,
        name: "An Introduction to C# learning cycle.",
        url: "https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/01.An_Introduction_To_The_C%23_Learning_Cycle.mp4",
        subCourseID: 1,
        title: "An Introduction to C# learning cycle.",
        desc: "Desc",
      });
      const handleUrl = (id) => {
        const linkData = motivationalData.find((item) => item.id === id && item);
        setLinkInfo(linkData);
        console.log(linkData);
        const link = linkData?.url;
        setVideoUrl(link);
      };
    
      
      const listStyle = {
          background:"#902167",
          color:"white",
          margin:"7px",
          padding:"10px",
          width:"30vw",
          borderRadius:"10px"
      }
      // #902167
      // #332155

    return (
        <div style={{ height: "100%" }} className={styles.starterBg}>
            <div >
                <Navigation></Navigation>
            </div>
            <div className="grid grid-cols-5 gap-4">
                
                <div
                style={{ height: "90vh" }}
                className="flex justify-center items-center col-span-3 "
                >
                <div>
                    <div
              style={{ background: "#332155", color: "white" }}
              className="my-5 text-center   p-5"
            >
              <p className=" font-bold">{linkInfo?.title}</p>
            </div>
                    <ReactPlayer controls url={videoUrl} />
                </div>
                </div>
                <div className="flex justify-center items-center col-span-2">
                    <div style={{height:"33rem"}} className="  overflow-auto rounded-2xl">
                        <div style={{backgroundColor:"#332155",padding: "1.75rem"}} className="p-7 ">
                            {
                                motivationalData.map(item => <p style={listStyle} className="cursor-pointer" onClick={()=>handleUrl(item.id)}>{item.title}</p> )
                            }
                        </div>
                    </div>
                </div>
        </div>
    </div>
    );
};

export default Motivational;