import React from 'react'
import './../../App.css'

function testPage() {

    let Question = (props) => {
        return <li className="text-3xl">{props.question}</li>
    }

    let Option = (props) => {
        return <li className="text-2xl bg-black py-2 px-10 rounded-3xl mx-5 my-10 cursor-pointer">{props.answer}</li>
    }

    return (
        <>
            <div className="absolute top-5 right-10 cursor-pointer text-5xl">&times;</div>

            <div className="absolute inset-0 m-auto shadow-2xl min-w-min w-3/4 h-3/4 border-4">
                <ol className="list-decimal mx-16 mt-20 mb-5">

                    <Question question="What is a bot ?" />

                </ol>

                <ol className="flex flex-wrap mt-10 mb-16 mx-8 text-white">

                    <Option answer="Captcha" />
                    <Option answer="Virtual Assistant" />
                    <Option answer="A robot" />
                    <Option answer="None of these" />

                </ol>
            </div>
        </>
    )
}

export default testPage
