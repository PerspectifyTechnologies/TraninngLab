// import { render } from '@testing-library/react'
import React, { useState, useEffect } from 'react'
import './../../App.css'
import Navbar from '../navbar/navbar'
import axios from 'axios'


function Eventpage() {

    //getting data from API

    const url = "http://localhost:44360/";

    const getEvents = () => {
        axios.get(`${url}events`)
            .then((response) => {
                const allEvents = response.data.events;
                console.log(allEvents);
            }).catch(error => console.log(`Error : ${error}`))
    }

    useEffect(() => {
        getEvents()
    }, []);

    const [events, setEvents] = useState('');




    let [transpile, transcription] = useState(true)


    return (
        <>

            {/* The below code is of top navbar */}

            <Navbar />

            {/* The below code is of the main display page */}


            <div  className=" mt-10 flex justify-center items-center flex-col mb-20 mx-10">


                {Object.keys(events).map(eve => {
                    return <div key={eve.id} className="flex w-full md:justify-between justify-center mx-10">

                        <iframe
                            src={eve.eventURL}
                            title={eve.eventName} frameBorder="0"
                            allow="accelerometer; autoplay; clipboard-write; encrypted-media;
                 gyroscope; picture-in-picture" allowFullScreen
                            className="md:h-auto md:w-8/12 h-96 w-full"
                        ></iframe>

                        {/* The below code is of courses playlist */}

                        <div className="w-80  bg-blue-400 hidden md:inline-block">
                            <div className="bg-blue-900 text-white text-xl text-center px-1 py-3 ">All Event's List</div>
                            <div className="w-full overflow-y-scroll h-96">


                                <div>
                                    <p className="bg-blue-600 p-2 text-xl text-white text-center">Current Events</p>
                                    <p className="m-2 bg-white rounded-md px-2 py-3 text-xl cursor-pointer">{eve.eventName}</p>
                                </div>

                           

                            </div>
                        </div>
                        <div className="mt-5 grid grid-cols-2 
                 w-full text-center text-xl py-2 px-1 gap-1 bg-blue-700 text-white">

                            <div className="py-3 px-2 cursor-pointer"
                                onClick={() => transcription(!transpile)}>Transcription</div>



                        </div>


                        <div className="z-0">
                            {transpile ? <div className="text-white bg-blue-500 text-xl p-5 ">
                                {eve.description}
                                <p>startTime : {eve.startTime} EndTime : {eve.EndTime}</p>

                            </div> : null}

                        </div>
                    </div>


                })}

            </div >



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

            <footer className="bg-gray-800 px-5 py-10
                  text-white text-center text-xl mt-5">
                All rights reserved
            </footer>

        </>
    )
}

export default Eventpage
