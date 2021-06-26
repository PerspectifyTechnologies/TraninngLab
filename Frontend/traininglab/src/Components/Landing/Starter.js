import React from 'react';
import { Route } from 'react-router';
import Navigation from './Navigation';
import cNetImage from '../../assets/cnet.svg'
import visualImage from '../../assets/visual.jpg'
import reactImage from '../../assets/react.png'
import styles from './starter.module.css'

const Starter = () => {
    
            const imgFlex = {
                display: "flex",
                justifyContent: "center",
                alignItems:"center",
                width:"25%",
                height: '30vh',
                backgroundColor: "#d8e3e7",
                borderRadius: "10px"
            } 


            const starterStyle = {
                height:"110vh"
            }
            
    return (
        <div>
            <div>
                <Navigation></Navigation>
            </div>
            <div style={starterStyle} class={styles.starterBg}>
                    <div className="">
                        <div style={{height: "90vh",display: "flex", justifyContent: "space-evenly",alignItems:"center"}}>
                            
                            <Route render={({history})=> (
                                <div onClick={()=> history.push("/net")} style={imgFlex} >
                                    <img style={{maxWidth: "100%",height: "auto", width:"25%"}} src={cNetImage} alt="" />
                                </div>
                            ) } />

                            <Route render={({history})=> (
                                <div onClick={()=> history.push("/visual")} style={imgFlex} >
                                    <img style={{maxWidth: "100%",height: "auto", width:"50%"}} src={visualImage} alt="" />
                                </div>
                            ) } />

                            <Route render={({history})=> (
                                <div onClick={()=> history.push("/react")} style={imgFlex} >
                                    <img style={{maxWidth: "100%",height: "auto", width:"50%"}} src={reactImage} alt="" />
                                </div>
                            ) } />

                        </div>
                    </div>
            </div>
        </div>
    );
};

export default Starter;