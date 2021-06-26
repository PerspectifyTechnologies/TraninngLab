import React, { useEffect } from "react";
import styles from "./net.module.css";
import ReactPlayer from "react-player";
import { useState } from "react";

const Net = () => {
  const [videoUrl, setVideoUrl] = useState("https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/01.An_Introduction_To_The_C%23_Learning_Cycle.mp4");

  const courseData = [{"courseID":1,"name":"An Introduction to C# learning cycle.","url":"https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/01.An_Introduction_To_The_C%23_Learning_Cycle.mp4","subCourseID":1,"title":"Title","desc":"Desc"},{"courseID":1,"name":"How To Install Visual Studio-2019","url":"https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/02.How_To_Install_Visual_Studio-2019.mp4","subCourseID":2,"title":"How To Install Visual Studio-2019","desc":"Desc"},{"courseID":1,"name":" Intro to Visual Studio 2019, What's New?","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/03.Intro_to_Visual_Studio_2019-What's_New%2C_What's_Better%2C_and_Why_You_Should_Upgrade.mp4\n","subCourseID":3,"title":" Intro to Visual Studio 2019, What's New?","desc":"Desc"},{"courseID":1,"name":"\nTop 10 Hidden Gems in Visual Studio\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/04.Top_10_Hidden_Gems_in_Visual_Studio-Speed_Up_Development_Without_Increasing_Your_Costs.mp4","subCourseID":4,"title":" Top 10 Hidden Gems in Visual Studio ","desc":"Desc"},{"courseID":1,"name":"Visual Studio Editor Tips","url":"https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/05.15_Visual_Studio_Editor_Tips_including_Intellicode_and_EditorConfig.mp4\n","subCourseID":5,"title":"Visual Studio Editor Tips","desc":"Desc"},{"courseID":1,"name":"Getting help online as a Developer\n","url":"https://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/06.How_to_Get_Help_Online_as_a_Software_Developer.mp4\n","subCourseID":6,"title":"Getting help online as a Developer ","desc":"Desc"},{"courseID":1,"name":"Debugging and Breakpoints\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/07.C%23_Debugging__Breakpoints.mp4","subCourseID":7,"title":"Debugging and Breakpoints ","desc":"Desc"},{"courseID":1,"name":"Handling Exceptions\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/08.Handling_Exceptions_in_C%23_-_When_to_catch_them%2C_where_to_catch_them%2C_and_how_to_catch_them.mp4","subCourseID":8,"title":"Handling Exceptions ","desc":"Desc"},{"courseID":1,"name":"Finding and Fixing Problems\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/09.Debugging_in_C%23_-_Finding_and_Fixing_Problems_in_Your_Application.mp4","subCourseID":9,"title":"Finding and Fixing Problems ","desc":"Desc"},{"courseID":1,"name":"Refactoring in C#\n","url":"\nhttps://prespectify-traininglab.s3.ap-south-1.amazonaws.com/C%23_for_BackEnd/10.Refactoring_in_C%23_-_Improving_an_Existing_Application.mp4","subCourseID":10,"title":"Refactoring in C# ","desc":"Desc"}]

  // console.log(courseData);

  useEffect(()=>{
    fetch("http://prespectify-traininglab.ap-south-1.elasticbeanstalk.com/api/QueryCourses/SubCourses?SubCourseID=1")
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
      });
  },[])

  // useEffect(()=>{
  //   fetch('http://prespectify-traininglab.ap-south-1.elasticbeanstalk.com/api/QueryCourses/SubCourses?SubCourseID=1', {
  //           method: 'GET', // *GET, POST, PUT, DELETE, etc.
  //           mode: 'cors', // no-cors, *cors, same-origin
  //           cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
  //           credentials: 'same-origin', // include, *same-origin, omit
  //           headers: {
  //                "Content-Type": "application/json"
  //           }
  //         })
  //         .then((res) => res.json())
  //         .then((data) => {
  //           console.log(data);
  //         });
  // },[])
 
    
      const handleUrl = (id) => {
        const linkData =  courseData.find(item=> (item.subCourseID === id) && item);
        
        const link = linkData?.url;
        setVideoUrl(link);
      };

      const listStyle = {
          background:"#63272A",
          color:"white",
          margin:"7px",
          padding:"10px",
          width:"30vw",
          borderRadius:"10px"
      }
      // #902167 #B05868 #804E48 #63272A
      // #332155 #2C070A #2D080B

  return (
    <div style={{ height: "100%" }} className={styles.starterBg}>
            
            <div className="grid grid-cols-5 gap-4">
                
                <div
                style={{ height: "100vh" }}
                className="flex justify-center items-center col-span-3 "
                >
                <ReactPlayer controls url={videoUrl} />
                </div>
                <div className="flex justify-center items-center col-span-2">
                    <div style={{height:"33rem"}} className="  overflow-auto rounded-2xl">
                        <div style={{backgroundColor:"#2D080B"}} className="p-7 ">
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

export default Net;
