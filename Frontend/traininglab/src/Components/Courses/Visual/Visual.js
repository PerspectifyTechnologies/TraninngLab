import React from 'react';
import styles from './visual.module.css';
import Navigation from '../../Landing/Navigation'

const Visual = () => {
    return (
        <div style={{height:"100vh"}} className={styles.starterBg}>
            <div>
                <Navigation></Navigation>
            </div>
        </div>
    );
};

export default Visual;