import React from 'react';
import Navigation from '../Landing/Navigation';
import styles from '../Landing/starter.module.css';
import EventDetails from "./EventDetails"

const Events = () => {

    // text-align: center !important;

    const eventStyle = {height:"100vh",color:"#fff"};

    return (
        <div>
            <Navigation></Navigation>
            <div style={eventStyle} className={styles.starterBg}>
                <div className="container mx-auto px-28">
                    <EventDetails></EventDetails>
                </div>
            </div>
        </div>
    );
};

export default Events;