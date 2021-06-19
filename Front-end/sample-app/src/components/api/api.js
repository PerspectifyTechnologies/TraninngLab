import React, { useState, useEffect } from 'react'
import axios from 'axios'
import './../../App.css'

function api(props) {

    //     const [users, setUsers] = useState([])
    //     const getUsers = async () => {
    //         const response = await fetch('https://jsonplaceholder.typicode.com/albums/1/photos')
    //         setUsers(await response.json())
    //     }
    //     useEffect(() => {
    //         getUsers()
    //     }, [])


    //     return (
    //         <>

    //             <div className='flex flex-wrap justify-center'>
    //                 {
    //                     users.map((currElem, key) => {
    //                         return (
    //                             <div key={key} className="m-5 flex justify-between border-4 text-xl text-center w-64 h-auto">
    //                                 <div className="">
    //                                     {currElem.title}
    //                                 </div>
    //                                 <img src={currElem.url} alt="" className='w-10 h-10 ' />
    //                             </div>
    //                         )
    //                     })
    //                 }

    //             </div>

    //         </>
    //     )
    const [num, setNum] = useState()
    let number = 0

    useEffect(() => {
        async function getData() {
            const response = await axios.get('https://jsonplaceholder.typicode.com/albums/1/photos')
            setNum(response.data[number].title)
        }
        getData()
    })

    const Gamepaad = () => {
        ++number
    }
    return (
        <div className="flex justify-center relative">
            <div className="absolute top-0 left-0 bottom-0 right-0 mx-auto mt-10 border-4 py-5 px-5 shadow-2xl w-96 h-64">
                <div className="p-5">Question.</div>
                <div className="p-5">Answer: {num}</div>
            </div>

            <button onClick={() => Gamepaad()}>Click me</button>
        </div>
    )

}

export default api






