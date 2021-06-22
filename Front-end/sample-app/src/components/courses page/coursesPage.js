import React, { useCallback } from 'react'
import './../../App.css'
import { Redirect, Route} from 'react-router-dom'
import Navbar from './../navbar/navbar'
import CoursesBackPage from './../../assets/19362653.jpg'
import { motion } from 'framer-motion'
import ReactPage from './react'
import { useHistory } from "react-router-dom"
import Angular from './Angular'

function CoursesPage() {


<<<<<<< HEAD
    const courses = [
        {
            id: 1,
            name: "React"
        },
        {
            id: 2,
            name: "c#"
        },
        {
            id: 3,
            name: "Blender"
        },
        {
            id: 4,
            name: "MongoDB"
        },
        {
            id: 5,
            name: "react"
        }]

    const history = useHistory();


=======
// const courses = [
//     {
//         id : 1,
//         name : "React"
//     },
//     {
//         id : 2,
//         name : "c#"
//     },
//     {
//         id : 3,
//         name : "Blender"
//     },
//     {
//         id : 4,
//         name : "MongoDB"
//     },
//     {
//         id : 5,
//         name : "Angular"
//     }]
  
    const history = useHistory();


 
>>>>>>> 794daa231597c8b19ad2f22348990b1f109c25b6

    return (
        <div className='w-screen overflow-hidden'>


            <motion.div
                initial={{ marginLeft: '100vw' }}
                animate={{ marginLeft: 0 }}
                transition={{ duration: 0.5, type: 'spring', stiffness: 200, delay: 0.2 }}
            >
                <div className="relative top-0 left-0 right-0 bottom-0 over h-screen w-screen">
                    <Navbar />
                    <img src={CoursesBackPage} alt="" className="absolute

             top-0 bottom-0 left-0 right-0 w-screen h-screen z-0 " />
<<<<<<< HEAD
                    <div className="flex flex-wrap justify-center items-center m-5 bg-transparent absolute z-40">
                        {courses.map(course => {
                            return (
                                <motion.div whileHover={{ scale: 1.1 }}
                                    whileTap={{ scale: 0.9 }} key={course.id} className="inline-block shadow-2xl py-10 px-16 border-2
                       m-5 rounded-3xl cursor-pointer text-3xl bg-white" onClick={() => history.push('./courses/react')}>
                                    {course.name}
                                </motion.div>
                            )
                        })}
                    </div>
                </div>
            </motion.div></div>
=======
            <div className="flex flex-wrap justify-center m-5 bg-transparent absolute z-40">
            
                    <motion.button  whileHover={{ scale: 1.1 }}
                    whileTap={{ scale: 0.9 }} className="inline-block shadow-2xl py-10 px-16 border-2
                       m-5 rounded-3xl cursor-pointer text-3xl bg-white" onClick ={() => history.push('/courses/react')}>React
                      </motion.button>
                      
                    <motion.button  whileHover={{ scale: 1.1 }}
                    whileTap={{ scale: 0.9 }} className="inline-block shadow-2xl py-10 px-16 border-2
                       m-5 rounded-3xl cursor-pointer text-3xl bg-white" onClick ={() => history.push('/courses/angular')}>Angular
                      </motion.button>
                      
                    <motion.button  whileHover={{ scale: 1.1 }}
                    whileTap={{ scale: 0.9 }} className="inline-block shadow-2xl py-10 px-16 border-2
                       m-5 rounded-3xl cursor-pointer text-3xl bg-white" onClick ={() => history.push('/courses/dotnet')}>DotNet
                      </motion.button>
                      
                    <motion.button  whileHover={{ scale: 1.1 }}
                    whileTap={{ scale: 0.9 }} className="inline-block shadow-2xl py-10 px-16 border-2
                       m-5 rounded-3xl cursor-pointer text-3xl bg-white" onClick ={() => history.push('/courses/nodejs')}>Nodejs
                      </motion.button>
                      
                    <motion.button  whileHover={{ scale: 1.1 }}
                    whileTap={{ scale: 0.9 }} className="inline-block shadow-2xl py-10 px-16 border-2
                       m-5 rounded-3xl cursor-pointer text-3xl bg-white" onClick ={() => history.push('/courses/csharp')}>C#
                      </motion.button>
         
            </div>
        </>
>>>>>>> 794daa231597c8b19ad2f22348990b1f109c25b6
    )
}

export default CoursesPage
