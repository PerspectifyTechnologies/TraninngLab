import React from 'react';
import Navigation from '../Landing/Navigation';
import styles from '../Landing/starter.module.css';
import EventDetails from "./EventDetails"
import Notification from './Notification';
import Option from './Option';
import VideoPlayer from './VideoPlayer';
import {ContextProvider} from './SocketContext';

const MainEvent = () => {
    const eventStyle = {height:"100vh",color:"#fff"};
    return (
        <div>
            <Navigation></Navigation>
            <div style={eventStyle} className={styles.starterBg}>
                <VideoPlayer ></VideoPlayer>
                <div>
                    <Option>
                        <Notification />
                    </Option>
                </div>
            </div>
        </div>
    );
};

export default MainEvent;