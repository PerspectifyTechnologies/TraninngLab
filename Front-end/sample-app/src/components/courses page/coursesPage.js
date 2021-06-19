import React, {useCallback} from 'react'
import './../../App.css'
import Navbar from './../navbar/navbar'
import CoursesBackPage from './../../assets/19362653.jpg'
import { motion } from 'framer-motion'
import ReactPage from './react'
import { useHistory } from "react-router-dom"

function CoursesPage() {


const courses = [
    {
        id : 1,
        name : "React"
    },
    {
        id : 2,
        name : "c#"
    },
    {
        id : 3,
        name : "Blender"
    },
    {
        id : 4,
        name : "MongoDB"
    },
    {
        id : 5,
        name : "react"
    }
]
  
const history = useHistory();

 

    return (
        <>

            <Navbar />
            <img src={CoursesBackPage} alt="" className="absolute
             top-0 bottom-0 left-0 right-0 w-screen h-screen z-0 " />
            <div className="flex flex-wrap justify-center m-5 bg-transparent absolute z-40">
            {courses.map(course => {
                return (
                    <motion.div  whileHover={{ scale: 1.1 }}
                    whileTap={{ scale: 0.9 }} key = {course.id} className="inline-block shadow-2xl py-10 px-16 border-2
                    //      m-5 rounded-3xl cursor-pointer text-3xl bg-white" onClick = {() => history.push('./courses/react')}>
                        {course.name}
                    </motion.div>
                )
            })}
            </div>

        </>
    )
}

export default CoursesPage
