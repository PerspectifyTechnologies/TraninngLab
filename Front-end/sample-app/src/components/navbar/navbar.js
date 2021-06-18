import React from 'react'
import notification from './../../assets/notification.png'


function navbar() {
    let notificationCount = 2
    return (
        <>
            <div className="sticky top-0
     left-0 right-0 text-center py-3 bg-blue-500 text-3xl
      text-white flex justify-between md:px-20 px-8 z-50">
                <span className="my-auto">Training lab</span>

                <span className="flex">
                    <img src={notification} alt="notification"
                        className="cursor-pointer w-8 h-8 my-auto" />
                    <span className="text-base">{notificationCount}</span>
                </span>
            </div>
        </>
    )
}

export default navbar
