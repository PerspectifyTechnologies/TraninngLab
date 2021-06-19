import React from 'react'
import './../../App.css'
import { Link } from 'react-router-dom'
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
             top-0 bottom-0 left-0 right-0 w-screen md:h-screen h-full z-0 " />

            <div className="flex flex-wrap justify-center my-32 mx-5 bg-transparent absolute z-40 w-auto">

                <Link to='/testPage'>
                    <Course course="C#" />
                </Link>
                <Link to='/testPage'>
                    <Course course="React" />
                </Link>
                <Link to='/testPage'>
                    <Course course=".Net" />
                </Link>
                <Link to='/testPage'>
                    <Course course="Angular" />
                </Link>
                <Link to='/testPage'>
                    <Course course="MongoDB" />
                </Link>
                <Link to='/testPage'>
                    <Course course="MySql" />
                </Link>
                <Link to='/testPage'>
                    <Course course="Node.js" />
                </Link>

            </div>

        </>
    )
}

export default coursesPage
