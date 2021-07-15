import React from 'react';
import Navigation from '../Landing/Navigation';
import EventDetails from './EventDetails';
import styles from '../Landing/starter.module.css';
import MainEvent from './MainEvent';
import {ContextProvider} from  './SocketContext';
const Events = () => {

    const eventStyle = {height:"100vh",color:"#fff"};

    return (
        // <ContextProvider>
        //     <MainEvent/>
        // </ContextProvider>
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