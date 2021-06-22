import React, { useState } from 'react'
import ReactPlayer from 'react-player'
import Navbar from '../navbar/navbar'
import { motion } from 'framer-motion'


const Courses = () => {
    const [nav, openNav] = useState(false)
    const changer = () => {
        if (nav) {
            openNav(false)
        }
        if (!nav) {
            openNav(true)
        }
    }


    const titleArr = [
        {
            title: 'Introduction of React'
        },
        {
            title: 'Setting up React Project'
        },
        {
            title: 'Understanding the Folder Structure'
        },
        {
            title: 'JSX Element'
        },
        {
            title: 'Hello World!'
        },
    ]

    const Chapter = (props) => {
        return (
            <p className=" pl-5 my-4 pb-3 cursor-pointer border-b-2 text-white border-gray-300">{props.title}</p>

        )
    }

    return (
        <div className='overflow-hidden'>
            <motion.div
                initial={{ scale: 0 }}
                animate={{ scale: 1 }}
                transition={{ delay: 1 }}
                className='relative top-0 right-0 left-0 bottom-0'
            >
                <Navbar />
                <div className="flex md:justify-between justify-center flex-col md:flex-row bg-no-repeat bg-cover mt-0 md:mt-24 md:mx-10 mx-0 mb-10" >

                    <motion.div
                        animate={nav ? { height: '100%', width: '64%' } : null}
                        className="flex flex-col md:hidden fixed top-0 right-0 bg-blue-600 z-40 w-0 h-0 overflow-hidden">

                        <motion.div
                            initial={{ marginTop: '100vh', opacity: 0 }}
                            animate={nav ? { marginTop: 0, opacity: 1 } : { marginTop: '100rem', opacity: 0 }}
                            transition={{ duration: 0.8 }}

                            className="flex flex-col justify-center" >
                            <div className="bg-green-500 inline-block mx-auto mt-10 mb-5 p-10 rounded-full"></div>
                            <div className="my-5 text-white text-2xl text-center">Lalit Chowdhery</div>
                            {
                                titleArr.map((props, index) => {
                                    return (
                                        <Chapter title={props.title} key={index} />
                                    )
                                })
                            }
                        </motion.div>

                    </motion.div>

                    <div className="md:hidden flex bg-white w-32 my-5 mx-5 border-4 p-3 rounded-xl text-2xl cursor-pointer z-30"
                        onClick={changer}>☰ Menu</div>

                    <div className="flex justify-center items-center flex-col">
                        <div className=" w-full md:mx-0 mx-10 h-full z-10">
                            <ReactPlayer controls width='100%' height="400px" url="https://www.youtube.com/watch?v=JPT3bFIwJYA" />
                        </div>
                        <div>
                            <textarea className="w-auto border mt-10 border-gray-900 " rows="10" cols="100" name="comment" form="usrform" placeholder="Take notes..."></textarea>
                        </div>
                    </div>

                    <div className=" bg-blue-500 text-white w-4/12 h-auto  border-gray-300 hidden md:block">

                        {
                            titleArr.map((props, index) => {
                                return (
                                    <Chapter title={props.title} key={index} />
                                )
                            })
                        }

                    </div>

                </div>
            </motion.div>
        </div >
        // =======
        // import React, { useState, useEffect } from 'react'
        //     import ReactPlayer from 'react-player'
        //     import Navbar from '../navbar/navbar'
        //     import axios from 'axios'


        //     const Courses = () => {

        //         const [courses, setCourses] = useState("")

        //         const url = "http://localhost:44360/";

        //         const getCourses = () => {
        //             axios.get(`${url}courses`)
        //                 .then((response) => {
        //                     const allCourses = response.data.courses;
        //                     setCourses(allCourses)
        //                 }).catch(error => console.log(`Error : ${error}`))
        //         }


        //         useEffect(() => {
        //             getCourses()
        //         }, []);

        //         return (
        //             <div>
        //                 <Navbar />
        //                 <div className="flex justify-between bg-no-repeat bg-cover" >

        //                     {courses.map(course => {
        //                         return (
        //                             <div>
        //                                 <div className="w-full mt-14 ml-24">

        //                                     <ReactPlayer controls width="720px" height="400px" url="https://www.youtube.com/watch?v=JPT3bFIwJYA" />
        //                                     <div>
        //                                         <textarea className="border-1 mt-10 mb-10 border-gray-900" rows="10" cols="100" name="comment" form="usrform" placeholder="Take notes..."></textarea>
        //                                     </div>
        //                                 </div>
        //                                 <div className=" bg-blue-900 text-white mt-10 mr-8 w-4/12 h-screen mb-10 border-2 border-gray-300">
        //                                     <p className="mt-4 pl-5 mb-4 pb-3 cursor-pointer border-b-2 border-gray-300">{course.chapters}</p>

        //                                 </div>
        //                             </div>
        //                         )
        //                     })}


        //                 </div>

        //             </div>
        //             // >>>>>>> 794daa231597c8b19ad2f22348990b1f109c25b6
        //         )
        //     }
    )
}
export default Courses