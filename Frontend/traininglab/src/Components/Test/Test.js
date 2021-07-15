import React, { useEffect, useState } from 'react';
import Navigation from '../Landing/Navigation';
import styles from '../Landing/starter.module.css';
import queryTest from './TestEasyData';
import axios from "axios";
import ok from '../../assets/ok.png'; 
import lessgo from '../../assets/arrow.png'; 
import notok from '../../assets//notok.png'; 
import { useHistory} from "react-router-dom";

const Test = () => {

	const [testCourseUrl, setTestCourseUrl] =  useState("");

    const [newData,setNewData] = useState([]); 
    const [QuesData,setQuesData] = useState([]); 
    const [OptData,setOptData] = useState([]); 
    const [selectedData] = useState([]); 
	const [currentQuestion, setCurrentQuestion] = useState(0);
	const [Total, setTotal] = useState(0);
	const [showScore, setShowScore] = useState(false);
	const [showSheet, setShowSheet] = useState(false);
	const [score, setScore] = useState(0);
	const [courseID, setCourseID] = useState(0);
	const [levelID, setLevelID] = useState(1);
    const [levelData,setLevelData] = useState([]); 
	const handleAnswerOptionClick = (isCorrect,Answer) => {
		selectedData.push(Answer);
		if (isCorrect) {
			setScore(score + 1);
		}

		const nextQuestion = currentQuestion + 1;
		if (nextQuestion < QuesData.length) {  //this line
			setCurrentQuestion(nextQuestion);
		} else {
			setShowScore(true);
		}
	};

    const cardStyle = {
        background:"#171E27",
        textAlign:"center"
    };

    const sheetStyle = {
        background:"#171E27",
        textAlign:"center",
		padding: 1 ,

    };
    const btnStyle = {
		color : "black",
        background:"#b88a00",
        padding:"10px",
        borderRadius:"10px"
    }

	const testData = [
		{ id:1, 
		name:".Net",
		},
		{ id:2, 
			name:"React",
		},
		{ id:3, 
			name:"Visual Design",
		},
	]

	const handleUrl = (id) =>{
		const preUrl = `https://localhost:44388/api/test/${id}`;
		setCourseID(id);
		setTestCourseUrl(preUrl);
		getLevelDetails(id);
	}
	const getLevelDetails = (id) => {
		fetch(`https://localhost:44388/api/test/courseid/${id}`)
		.then((res) => res.json())
		 .then((data) => {
			 console.log(data);
			 setLevelData(JSON.parse(data));
		 });
	}
	const handleTest = (id) => {
		var testQuestion = [];
		var testOptions = [];
		testQuestion = newData.map(item => item.Question);
		testOptions = newData.map(item => item.Options);
		setTotal(testQuestion.length);
		setQuesData(testQuestion);
		setOptData(testOptions);
		setLevelID(id);
	}

	const updateScore = () =>{
		setShowSheet(true);
		if((score/Total)*100 >= 60){
			var session = JSON.parse(localStorage.getItem("user"));
			var postData = {
			score : (score*5),
			username : session.username
		  };
		  console.log(levelID);
			axios.post(`https://localhost:44388/api/test/${courseID}/${levelID}/update`,postData)
			.then((res) => {
				alert(`you scored ${score} out of 5`);
			})
		}
		else{
			alert('You did not passed the test.. dont lose hope');
		}
	}
	useEffect(()=>{
		fetch(testCourseUrl)
		   .then((res) => res.json())
			.then((data) => {
		   setNewData(JSON.parse(data));
			});
	},[testCourseUrl])

	const testtakenstyle = {
		color:"#FFC107",
		background: "#495057",
		padding: "10px 70px",
		marginBottom:"10px",
		borderRadius:"20px",
		display: "flex"
	}
	const testnottakenstyle = {
		color:"black",
		background: "#b88a00",
		padding: "10px 70px",
		marginBottom:"10px",
		borderRadius:"20px",
		display: "flex"
	}
	const testCourseStyle = {
		background: "#261A40",
		padding: "10px 70px",
		margin:"10px",
		borderRadius:"20px"
	}

	const sheetQuestionStyle ={
		background: "#261A40",
		padding: "10px 70px",
		margin:"10px",
		borderRadius:"20px"
	}
	const sheetOptionStyle ={
		background: "#FFFFFF",
		padding: "10px 70px",
		margin:"5px",
		borderRadius:"20px",
		display: "table", 
	}

	let history = useHistory();
    return (
            <div>
                <Navigation></Navigation>
				{showSheet?(
				<div style={{height:"100vh", color:"white",background:"#261A40"}} className={styles.starterBg}>
						<div style={sheetStyle}>
									{newData.map(item => <div style={sheetQuestionStyle}>{<div >Q.{item.QuesID}  {item.Question} {item.Options.map(option =>
										<div style={sheetOptionStyle}><p style = {
											(option.IsCorrect)?
											({color:"blue",display: "inline"}):
										((selectedData[item.QuesID-1]===option.Answer)?
										({color:"red",display: "inline"}):
										({color:"black",display: "inline"})) }>
											{option.Answer}
											{(option.IsCorrect)?(<p> <img style ={{borderRadius: "10px"}} src={ok}  width="25" height="25" ></img> </p>):
											((selectedData[item.QuesID-1]===option.Answer)?
											(<p><img style={{borderRadius: "10px"}} src={notok} width="28" height="28" ></img></p>):
											(<p></p>))}
											</p></div>)}
											</div>}</div>)}
											<p style={sheetQuestionStyle}>scored {score} out of 5</p>
											<button style={btnStyle} onClick={()=>history.push("/ProfilePage")} className="mb-5" >Done, here</button>
										</div>
							</div>
				):(<div style={{height:"100vh", color:"white"}} className={styles.starterBg}>
					<div className="flex justify-evenly">
						{ 
							testData.map(item => <button style={testCourseStyle} onClick={()=>handleUrl(item.id)}>{item.name}</button>)
						}
					</div>
						
                    <div style={{height:"90vh", color:"white"}} className={"flex justify-evenly items-center"}>
						<div style={{height:"100%"}} className="flex justify-center items-center">
							<div>
								{ 
									levelData.map(item => <div><div style={(item.HasTaken)?(testtakenstyle):(testnottakenstyle)} 
									onClick={(item.NextInLine)?(()=>handleTest(item.LevelID)):({})}>{item.LevelName}
									{(item.NextInLine)?(<p style ={{marginLeft : "1rem"}} role="button"><img style ={{borderRadius: "15px"}} src={lessgo}  width="30" height="30" ></img></p>):(<p></p>)}</div></div>)
								}
							</div>
						</div>
						<div style={cardStyle} className='flex justify-evenly items-center w-3/5 h-72'>
						{showScore ? (
							<div className='score-section'>
								<button style={btnStyle} className="mb-5" onClick={() => updateScore()}>submit</button>
							</div>
						) : (
							<>
								<div className='question-section'>
									<div className='mb-5'>
										 {(Total !==0)?
											 (<p><span>Question {currentQuestion + 1}</span>/{Total}</p>):
											 (<p>Your Questions will come Here</p>)
											}
									</div>
									<div className='question-text'>{QuesData[currentQuestion]}</div>
								</div>
								<div className='flex  flex-col '>
									{OptData[currentQuestion]?.map((item) => (
										<button style={btnStyle} className="mb-5" onClick={() => handleAnswerOptionClick(item.IsCorrect,item.Answer)}>{item.Answer}</button>
									))}
								</div>
							</>
						)}
						</div>
                    </div>
                </div>)}
                
            </div>
            
    );
};

export default Test;
