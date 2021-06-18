import React from 'react'
import './../../App.css'

function testPage() {

    let Question = (props) => {
        return <div>{props.question}</div>
    }

    let Option = (props) => {
        return <div className="text-center  text-2xl bg-black py-2 px-5 rounded-3xl m-5 cursor-pointer">{props.answer}</div>
    }

    return (
        <>
            <div className="absolute top-5 right-10 cursor-pointer text-5xl">&times;</div>

            <div className="overflow-hidden relative top-0 bottom-0 left-0 right-0 mx-auto mt-24 shadow-2xl min-w-min w-3/4 h-auto  border-4">
                <div className="mt-10 mx-16">

                    <div className="flex text-3xl">
                        Q.<Question question="What is a bot ?" />
                    </div>

                    <div className="flex flex-wrap justify-center mt-10 text-white">

                        <Option answer="Captcha" />
                        <Option answer="Virtual Assistant" />
                        <Option answer="A robot" />
                        <Option answer="None of these" />

                    </div>
                </div>

                <div className="flex float-right mx-5 mt-24 mb-10">
                    <div className="border-2 border-red-500 text-red-500 cursor-pointer mx-5 px-4 py-2 rounded-xl hover:text-white hover:bg-red-500 duration-200">Previous</div>
                    <div className="border-2 border-blue-500 text-blue-500 cursor-pointer mx-5 px-4 py-2 rounded-xl hover:text-white hover:bg-blue-500 duration-200">Next</div>
                </div>
            </div>
        </>
    )
}

export default testPage
