import React, { useContext } from 'react';
import {SocketContext} from './SocketContext';

const VideoPlayer = () => {
    const {name, callAccepted, myVideo, userVideo, callEnded, stream , call} = useContext(SocketContext) ;

    console.log("myvideo",myVideo);
    const videoStyle = {
        height: "200px",
        width: "200px",
        backgroundColor:"#fff"
    }
    return (
        <div>
            
            {stream && (
                <div style={videoStyle}>
                <p>{name || "name"}</p>
                <video src={myVideo}></video>
            </div>
            )}
            {callAccepted && !callEnded && (
                <div style= {videoStyle}>
                <p>{call.name || "name"}</p>
                    <video src={userVideo}></video>
                </div>
            )}
        </div>
    );
};

export default VideoPlayer;