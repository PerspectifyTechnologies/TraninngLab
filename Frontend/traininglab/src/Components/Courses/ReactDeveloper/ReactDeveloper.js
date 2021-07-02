import React, { useEffect, useState } from 'react';
import styles from './reactdevelop.module.css'
import ReactPlayer from "react-player";

const ReactDeveloper = () => {

    const [videoUrl, setVideoUrl] = useState("\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/01.ReactJS_Tutorial_-_1_-_Introduction.mp4\n");

  const courseData = [{"courseID":2,"name":"Introduction\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/01.ReactJS_Tutorial_-_1_-_Introduction.mp4\n","subCourseID":11,"title":"Introduction ","desc":"Desc"},{"courseID":2,"name":"Hello World\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/02.ReactJS_Tutorial_-_2_-_Hello_World.mp4\n","subCourseID":12,"title":"Hello World ","desc":"Desc"},{"courseID":2,"name":"Folder Structure\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/03.ReactJS_Tutorial_-_3_-_Folder_Structure.mp4\n","subCourseID":13,"title":"Folder Structure ","desc":"Desc"},{"courseID":2,"name":"Components\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/04.ReactJS_Tutorial_-_4_-_Components.mp4\n","subCourseID":14,"title":"Components ","desc":"Desc"},{"courseID":2,"name":"Functional Components\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/05.ReactJS_Tutorial_-_5_-_Functional_Components.mp4\n","subCourseID":15,"title":"Functional Components ","desc":"Desc"},{"courseID":2,"name":"Class Components\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/06.ReactJS_Tutorial_-_6_-_Class_Components.mp4\n","subCourseID":16,"title":"Class Components ","desc":"Desc"},{"courseID":2,"name":"Hooks Update\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/ReactJS_for_FrontEnd/07.ReactJS_Tutorial_-_7_-_Hooks_Update.mp4\n","subCourseID":17,"title":"Hooks Update ","desc":"Desc"}]

//   console.log(courseData);

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
    const linkData = courseData.find((item) => item.subCourseID === id && item);
    setLinkInfo(linkData);
    const link = linkData?.url;
    setVideoUrl(link);
  };
    
      

      const listStyle = {
          background:"#5F7680",
          color:"white",
          margin:"7px",
          padding:"10px",
          width:"30vw",
          borderRadius:"10px"
      }
      // #902167 #5F7680 
      // #332155 #143753

  return (
    <div style={{ height: "100%" }} className={styles.starterBg}>
            
            <div className="grid grid-cols-5 gap-4">
                
                <div
                style={{ height: "100vh" }}
                className="flex justify-center items-center col-span-3 "
                >
                    <div>
                    <div style={{background:"#143753",color:"white"}} className="my-5 text-center   p-5">
              <p className=" font-bold">{linkInfo.title}</p>
            </div>
                <ReactPlayer controls url={videoUrl} />
                    </div>
                </div>
                <div className="flex justify-center items-center col-span-2">
                    <div style={{height:"33rem"}} className="  overflow-auto rounded-2xl">
                        <div style={{backgroundColor:"#143753",padding: "1.75rem"}} className="p-7 ">
                            {
                                courseData.map(item => <p style={listStyle} className="cursor-pointer" onClick={()=>handleUrl(item.subCourseID)}>{item.name}</p> )
                            }
                        </div>
                    </div>
                </div>
        </div>
    </div>
  );
};

export default ReactDeveloper;