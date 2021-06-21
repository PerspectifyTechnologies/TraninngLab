import React from 'react'
import { Link } from 'react-router-dom'
import './../../App.css'
import BackPage from './../../assets/4380.jpg'

function frontPage(props) {
    return (
        <><img src={BackPage} alt="" className="w-screen h-1/2 sm:h-screen absolute top-0 left-0 right-0 bottom-0 " />

            <div className="absolute top-2 right-2 flex mt-2 mr-4">
                <div className="mx-2 border-2 rounded-xl 
                px-4 py-2 border-blue-500 text-blue-500 cursor-pointer
                 duration-200 hover:bg-blue-500 hover:text-white text-2xl bg-white" >Sign in</div>

                <Link to='/signUp'>
                    <div className="mx-2 border-2 rounded-xl px-4 py-2
                 border-blue-500 text-blue-500 cursor-pointer duration-200
                  hover:bg-blue-500 hover:text-white text-2xl bg-white">Sign up</div>
                </Link>
            </div>

            <div className="absolute left-0 right-0 sm:top-72 top-48 flex justify-center ">
                <Link to="/courses">
                    <div className="border-2 rounded-xl px-4 py-2 border-blue-500
                 text-blue-500 cursor-pointer duration-200 hover:bg-blue-500
                  hover:text-white text-2xl bg-white" onClick={props.next}> Get Started </div>
                </Link>
            </div></>
    )
}
export default frontPage
