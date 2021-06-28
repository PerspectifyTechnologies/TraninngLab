import React from "react";

const EventDetails = () => {

    const buttonStyle = {
        border:"2px solid #8A2066",
        padding:"7px 15px",
        marginRight:"10px",
        borderRadius:"7px",
    }

  return (
    <div className="flex justify-center ">
      <div style={{ background:"#1D1534",borderRadius:"10px"}} className="w-3/5 p-5 mt-5">
        <div className="flex justify-center mb-4">
          <img width="60%"
            src="https://scontent.fdac13-1.fna.fbcdn.net/v/t1.6435-9/p960x960/206945676_220362023257207_19681846088328936_n.jpg?_nc_cat=108&ccb=1-3&_nc_sid=340051&_nc_ohc=s4yk_ZDvljQAX_g7SWT&_nc_ht=scontent.fdac13-1.fna&tp=6&oh=2c700c462c27d718d60e1c6204a17c03&oe=60DA0B98"
            alt=""
          />
        </div>
        <div className="my-4">
          <p style={{color:"#8A2066"}} className="font-bold">TOMORROW AT 10 AM UTC+06 – 11:45 AM UTC+06</p>
          <h1 className="text-3xl font-bold flex my-2">
          <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-calendar-event" viewBox="0 0 16 16">
            <path d="M11 6.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-1a.5.5 0 0 1-.5-.5v-1z"/>
            <path d="M3.5 0a.5.5 0 0 1 .5.5V1h8V.5a.5.5 0 0 1 1 0V1h1a2 2 0 0 1 2 2v11a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V3a2 2 0 0 1 2-2h1V.5a.5.5 0 0 1 .5-.5zM1 4v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V4H1z"/>
            </svg>
              <span className="ml-5">React JS Workshop</span></h1>
        </div>

        <hr />

        <div className="my-4">
          <button style={buttonStyle}>Interested</button>
          <button style={buttonStyle}>Going</button>
        </div>

        <div className="my-4">
          <p>Event by Pathfinder ISSB Academy</p>
        </div>

        <div className="my-4">
          <p>
            React JS, we've all heard of the infamous javascript library, in
            this workshop, which is a collaboration with Google Developer
            Student Clubs ISSATso, we're going to learn all about the basics of
            this web development milestone, thanks to our brilliant mentor Aziz
            Bouchrit. You're welcome to join us on the google meet platform on
            Sunday, June 27th at 9pm : https://meet.google.com/xht-osvk-bik
          </p>
        </div>
      </div>
    </div>
  );
};

export default EventDetails;
