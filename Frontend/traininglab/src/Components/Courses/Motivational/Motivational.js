import React, { useState } from 'react';
import styles from '../../Landing/starter.module.css'
import ReactPlayer from "react-player";
import motivationalData from './motivationalData';
import styles1 from './Motivational.module.css';
import Navigation from '../../Landing/Navigation'

const Motivational = () => {


    
    
      const [videoUrl, setVideoUrl] = useState("https://www.youtube.com/watch?v=t1XCzWlYWeA")
    
      const handleUrl = (id) => {
        const linkData =  motivationalData.find(item=> (item.id === id) && item);
        
        const link = linkData?.url;
        setVideoUrl(link);
        console.log(link);
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
                <ReactPlayer controls url={videoUrl} />
                </div>
                <div className="flex justify-center items-center col-span-2">
                    <div style={{height:"33rem"}} className="  overflow-auto rounded-2xl">
                        <div style={{backgroundColor:"#332155"}} className="p-7 ">
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