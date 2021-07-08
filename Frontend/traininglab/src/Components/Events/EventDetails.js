import React from "react";
import { useState } from "react";
import eventData from './eventData';
const EventDetails = () => {

    const buttonStyle = {
        border:"2px solid #8A2066",
        padding:"7px 15px",
        marginRight:"10px",
        borderRadius:"7px",
    }
    // const eventDetails = {
    //   imageUrl:"https://scontent.fdac13-1.fna.fbcdn.net/v/t1.18169-9/1010076_477783955633350_1900224762_n.png?_nc_cat=109&ccb=1-3&_nc_sid=09cbfe&_nc_ohc=sYXJYwOodKUAX_LFJ9J&_nc_ht=scontent.fdac13-1.fna&oh=ab0a18d2bbad144c55fac93fb521f577&oe=60EA1701",
    //   eventDate:"2021-07-14",
    //   eventName:"React JS Workshop",
    //   eventBy:"Pathfinder ISSB Academy",
    //   eventDetails:"React JS, we've all heard of the infamous javascript library, in this workshop, which is a collaboration with Google Developer Student Clubs ISSATso, we're going to learn all about the basics of this web development milestone, thanks to our brilliant mentor Aziz Bouchrit. You're welcome to join us on the google meet platform on Sunday, June 27th at 9pm : https://meet.google.com/xht-osvk-bik"
    // }

    const [eventDetails, setEventDetails] = useState({
      imageUrl:"https://scontent.fdac13-1.fna.fbcdn.net/v/t1.18169-9/1010076_477783955633350_1900224762_n.png?_nc_cat=109&ccb=1-3&_nc_sid=09cbfe&_nc_ohc=sYXJYwOodKUAX_LFJ9J&_nc_ht=scontent.fdac13-1.fna&oh=ab0a18d2bbad144c55fac93fb521f577&oe=60EA1701",
      eventDate:"2021-07-14",
      eventName:"React JS Workshop",
      eventBy:"Pathfinder ISSB Academy",
      eventText:"React JS, we've all heard of the infamous javascript library, in this workshop, which is a collaboration with Google Developer Student Clubs ISSATso, we're going to learn all about the basics of this web development milestone, thanks to our brilliant mentor Aziz Bouchrit. You're welcome to join us on the google meet platform on Sunday, June 27th at 9pm : https://meet.google.com/xht-osvk-bik"
    });

    const {imageUrl,eventDate,eventName,eventBy,eventText} = eventDetails;

const handleDate = (e) => {
  const date = e.target.value;
  const newData =  eventData.find((item)=> item.eventDate === date && item)
  console.log(newData);
  setEventDetails(newData);
}

  return (
    <div className="flex justify-evenly  ">
        
        <div>
          <input onChange={(event)=>handleDate(event)} type="date" />
        </div>

      <div style={{ background:"#1D1534",borderRadius:"10px"}} className="w-3/5 p-5 mt-5">
        <div className="flex justify-center mb-4">
          <img style={{height:"250px"}}
            src={imageUrl}

            alt=""
          />
        </div>
        <div className="my-4">
          <p style={{color:"#8A2066"}} className="font-bold">{eventDate}</p>
          <h1 className="text-3xl font-bold flex my-2">
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-calendar-event" viewBox="0 0 16 16">
            <path d="M11 6.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-1a.5.5 0 0 1-.5-.5v-1z"/>
            <path d="M3.5 0a.5.5 0 0 1 .5.5V1h8V.5a.5.5 0 0 1 1 0V1h1a2 2 0 0 1 2 2v11a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V3a2 2 0 0 1 2-2h1V.5a.5.5 0 0 1 .5-.5zM1 4v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V4H1z"/>
            </svg>
              <span className="ml-5">{eventName}</span></h1>
        </div>

        <hr />

        <div className="my-4">
          <button style={buttonStyle}>Interested</button>
          <button style={buttonStyle}>Going</button>
        </div>

        <div className="my-4">
          <p>Event by {eventBy}</p>
        </div>

        <div className="my-4">
          <p>{eventText}</p>
        </div>
      </div>
    </div>
  );
};

export default EventDetails;
