import React, { useState, useEffect } from 'react'
import ReactPlayer from 'react-player'
import Navbar from '../navbar/navbar'
import axios from 'axios'


const Courses = () => {

    const [courses, setCourses] = useState("")

    const url = "http://localhost:44360/";

    const getCourses = () => {
        axios.get(`${url}courses`)
            .then((response) => {
                const allCourses = response.data.courses;
                setCourses(allCourses)
            }).catch(error => console.log(`Error : ${error}`))
    }


    useEffect(() => {
        getCourses()
    }, []);

    return (
        <div>
            <Navbar />
            <div className="flex justify-between bg-no-repeat bg-cover" >

                {courses.map(course => {
                    return (
                        <div>
                            <div className="w-full mt-14 ml-24">

                                <ReactPlayer controls width="720px" height="400px" url="https://www.youtube.com/watch?v=JPT3bFIwJYA" />
                                <div>
                                    <textarea className="border-1 mt-10 mb-10 border-gray-900" rows="10" cols="100" name="comment" form="usrform" placeholder="Take notes..."></textarea>
                                </div>
                            </div>
                            <div className=" bg-blue-900 text-white mt-10 mr-8 w-4/12 h-screen mb-10 border-2 border-gray-300">
                                <p className="mt-4 pl-5 mb-4 pb-3 cursor-pointer border-b-2 border-gray-300">{course.chapters}</p>
                               
                            </div>
                        </div>
                    )
                })}


            </div>

        </div>
    )
}

export default Courses