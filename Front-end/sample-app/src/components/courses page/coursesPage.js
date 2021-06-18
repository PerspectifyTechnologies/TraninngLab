import React from 'react'
import './../../App.css'
import Navbar from './../navbar/navbar'
import CoursesBackPage from './../../assets/19362653.jpg'
function coursesPage() {
    const Course = (props) => {
        return <div className="inline-block shadow-2xl py-10 px-16 border-2
         m-5 rounded-3xl cursor-pointer text-3xl bg-white">{props.course}</div>
    }
    return (
        <>

            <Navbar />
            <img src={CoursesBackPage} alt="" className="absolute
             top-0 bottom-0 left-0 right-0 w-screen h-screen z-0 " />
            <div className="flex flex-wrap justify-center m-5 bg-transparent absolute z-40">
                <Course course="C#" />
                <Course course="React" />
                <Course course="Blender" />
                <Course course="C#" />
                <Course course="React" />
                <Course course="Blender" />
                <Course course="C#" />
                <Course course="React" />
                <Course course="Blender" />
                <Course course="C#" />
                <Course course="React" />
                <Course course="Blender" />
            </div>

        </>
    )
}

export default coursesPage
