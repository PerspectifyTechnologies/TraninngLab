import React from 'react'
import ReactPlayer from 'react-player'
import Navbar from '../navbar/navbar'


const Courses = () => {
   return (
  <div>
      <Navbar />
        <div className = "flex justify-between bg-no-repeat bg-cover" >
        <div className = "w-full mt-14 ml-24">
            <ReactPlayer  controls width = "720px" height = "400px"  url = "https://www.youtube.com/watch?v=JPT3bFIwJYA" />
            <div>
    <textarea className = "border-1 mt-10 mb-10 border-gray-900" rows="10" cols="100" name="comment" form="usrform" placeholder = "Take notes..."></textarea>
    </div>
        </div>
        <div className = " bg-blue-900 text-white mt-10 mr-8 w-4/12 h-screen mb-10 border-2 border-gray-300">
            <p className = "mt-4 pl-5 mb-4 pb-3 cursor-pointer border-b-2 border-gray-300">Introduction of React</p>
            <p className = "mt-4 pl-5 mb-4 pb-3 cursor-pointer border-b-2 border-gray-300">Setting up React Project</p>
            <p className = "mt-4 pl-5 mb-4 pb-3 cursor-pointer border-b-2 border-gray-300">Understanding the Folder Structure</p>
            <p className = "mt-4 pl-5 mb-4 pb-3 cursor-pointer border-b-2 border-gray-300">JSX Element</p>
            <p className = "mt-4 pl-5 mb-4 pb-3 cursor-pointer border-b-2 border-gray-300">Hello World!</p>
        </div>
      
    </div>
   
  </div>
   ) 
}

export default Courses