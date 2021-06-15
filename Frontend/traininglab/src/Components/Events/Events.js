import React from "react";
import Navigation from "../Landing/Navigation";

const Events = () => {
  // text-align: center !important;

  return (
    <div>
      <Navigation />
      <div className="starterBg text-white h-eveHeight">
        <div>
          <h1 className="text-center py-10">Event Name</h1>
        </div>
        <div className="h-flexHeight flex items-center justify-center">
          <iframe
            width="700"
            height="406"
            src="https://www.youtube.com/embed/DLX62G4lc44"
            title="YouTube video player"
            frameborder="0"
            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
            allowfullscreen
          ></iframe>
        </div>
      </div>
    </div>
  );
};

export default Events;
