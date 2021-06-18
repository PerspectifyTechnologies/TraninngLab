// import { render } from '@testing-library/react'
import React, { useState } from 'react'
import './../../App.css'
import Navbar from './../navbar/navbar'


function testPage() {
    const event = "Event"

    const Transcript = () => {
        return (
            <div className="text-white bg-green-500 text-xl p-5 ">
                Lorem ipsum dolor, sit amet
                consectetur adipisicing elit. Minus error
                recusandae expedita aspernatur? Numquam provident,
                repellendus enim tempora quasi quibusdam voluptatum
                inventore minus aliquam amet minima eveniet soluta nam
                accusamus ducimus! Voluptatem, beatae error aliquid dolor
                id consectetur ullam repellat provident incidunt, quos quibusdam
                possimus eaque cumque adipisci, in amet!
                Lorem, ipsum dolor sit amet consectetur adipisicing elit.
                Neque velit dolores unde aliquid excepturi explicabo rem iusto
                temporibus ut alias blanditiis, modi nulla totam debitis sint
                repellendus labore et quam iure praesentium pariatur distinctio
                quidem saepe! Dolorem obcaecati possimus aliquam architecto sequi
                labore dolor praesentium exercitationem fugit quo. Quas, saepe!
            </div>
        )
    }

    const Notes = () => {
        return (
            <textarea className="bg-white text-2xl py-2 px-4 w-full h-32"
                placeholder="  Type your notes here...." cols="10">
            </textarea>
        )
    }

    const Video = (props) => {
        return (
            <div className="m-2 bg-white rounded-md px-2 py-3 text-xl cursor-pointer">{props.title}</div>
        )
    }
    const VideoHeading = (props) => {
        return (
            <div className="bg-green-600 p-2 text-xl text-white text-center">{props.heading}</div>
        )
    }

    const Panalist = (props) => {
        return (
            <div className="shadow-2xl py-2 px-1 text-white text-2xl flex justify-evenly">
                {props.children}
            </div>
        )
    }
    const PanelIcon = (props) => {
        return (
            <div className="bg-pink-500 w-12 h-12 rounded-full inline-block m-2 cursor-pointer">{props.icon}</div>
        )
    }

    let [transpile, transcription] = useState(true)
    let [userNotes, notes] = useState(false)


    return (
        <>

            {/* The below code is of top navbar */}

            <Navbar />

            {/* The below code is of the main display page */}


            <div className=" mt-10 flex justify-center items-center flex-col mb-20 mx-10">
                <div className="text-3xl mb-5">{event}</div>

                <div className="flex w-full md:justify-between justify-center mx-10">

                    <iframe
                        src="https://www.youtube.com/embed/JPT3bFIwJYA"
                        title="YouTube video player" frameBorder="0"
                        allow="accelerometer; autoplay; clipboard-write; encrypted-media;
                 gyroscope; picture-in-picture" allowFullScreen
                        className="md:h-auto md:w-8/12 h-96 w-full"
                    ></iframe>

                    {/* The below code is of courses playlist */}

                    <div className="w-80  bg-green-400 hidden md:inline-block">
                        <div className="bg-green-900 text-white text-xl text-center px-1 py-3 ">All Event's List</div>
                        <div className="w-full overflow-y-scroll h-96">

                            <VideoHeading heading="First half" />
                            <Video title="Introduction" />
                            <Video title="Event 1" />
                            <Video title="Event 2" />
                            <Video title="Event 3" />
                            <Video title="Event 4" />
                            <Video title="Event 5" />
                            <VideoHeading heading="Second half" />
                            <Video title="Event 6" />
                            <Video title="Event 7" />
                            <Video title="Event 8" />
                            <Video title="Event 9" />
                            <Video title="Event 10" />

                        </div>
                    </div>
                </div>

            </div >

            <div className="mt-5 grid grid-cols-2 
                 w-full text-center text-xl py-2 px-1 gap-1 bg-green-700 text-white">

                <div className="py-3 px-2 cursor-pointer"
                    onClick={() => transcription(!transpile)}>Transcription</div>

                <div className="py-3 px-2 cursor-pointer"
                    onClick={() => notes(!userNotes)}>Your Notes</div>

            </div>


            <div className="z-0">
                {transpile ? <Transcript /> : null}
                {userNotes ? <Notes /> : null}
            </div>

            {/* <div className="sticky bottom-0 left-0 right-0 bg-yellow-600 z-20">

                <Panalist>
                    <PanelIcon icon="1" />
                    <PanelIcon icon="2" />
                    <PanelIcon icon="3" />
                    <PanelIcon icon="4" />
                </Panalist>
                <Panalist>
                    <PanelIcon icon="5" />
                    <PanelIcon icon="6" />
                    <PanelIcon icon="7" />
                    <PanelIcon icon="8" />
                </Panalist>

            </div> */}

            <footer className="bg-gray-500 px-5 py-10
                  text-white text-center text-xl mt-5">
                All rights reserved
            </footer>

        </>
    )
}

export default testPage
