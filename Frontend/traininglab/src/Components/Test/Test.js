import React, { useEffect, useState } from 'react';
import Navigation from '../Landing/Navigation';
import styles from '../Landing/starter.module.css';
import queryTest from './TestEasyData';

const Test = () => {

	const [testCourseUrl, setTestCourseUrl] =  useState("");
	
	//console.log("test data",queryTest);
    const [questions,setQuestions] = useState([]); 

	const [currentQuestion, setCurrentQuestion] = useState(0);
	const [showScore, setShowScore] = useState(false);
	const [score, setScore] = useState(0);

	const handleAnswerOptionClick = (isCorrect) => {
		if (isCorrect) {
			setScore(score + 1);
		}

		const nextQuestion = currentQuestion + 1;
		if (nextQuestion < questions.length) {  //this line
			setCurrentQuestion(nextQuestion);
		} else {
			setShowScore(true);
		}
	};

    const cardStyle = {
        background:"#261A40",
        textAlign:"center"
    };

    const btnStyle = {
        background:"#9B236C",
        padding:"10px",
        borderRadius:"10px"
    }

	const testData = [
		{ id:1, 
		name:".Net",
		},
		{ id:2, 
			name:"Visual Design",
		},
		{ id:3, 
			name:"React",
		},
	]

	const handleUrl = (id) =>{
		const preUrl = `https://localhost:44388/api/QueryTests/${id}`;
		setTestCourseUrl(preUrl);
	}

	const handleTest = (id) => {
		const testQuestion = queryTest.find(item => item.id === id && item);
		setQuestions(testQuestion.question)
		console.log("test Q",testQuestion.question);
	}

	console.log(testCourseUrl);

	// useEffect(()=>{
	// 	fetch(testCourseUrl)
	// 		.then((res) => res.json())
	// 		.then((data) => {
	// 		  console.log("newData",data);
	// 		});
	// },[testCourseUrl])

	const testButtonStyle = {
		background: "#9B236C",
		padding: "10px 70px",
		marginBottom:"10px",
		borderRadius:"20px"
	}
	const testCourseStyle = {
		background: "#261A40",
		padding: "10px 70px",
		margin:"10px",
		borderRadius:"20px"
	}

    return (
            <div>
                <Navigation></Navigation>
                <div style={{height:"100vh", color:"white"}} className={styles.starterBg}>
					<div className="flex justify-evenly">
						{ 
							testData.map(item => <button style={testCourseStyle} onClick={()=>handleUrl(item.id)}>{item.name}</button>)
						}
					</div>
						
                    <div style={{height:"90vh", color:"white"}} className="flex justify-evenly items-center">
						<div style={{height:"100%"}} className="flex justify-center items-center">
							<div>
								{ 
									queryTest.map(item => <div><button style={testButtonStyle} onClick={()=>handleTest(item.id)}>{item.name}</button></div>)
								}
							</div>
						</div>
						<div style={cardStyle} className='flex justify-evenly items-center w-3/5 h-72'>
						{showScore ? (
							<div className='score-section'>
								You scored {score} out of {questions.length}
							</div>
						) : (
							<>
								<div className='question-section'>
									<div className='mb-5'>
										<span>Question {currentQuestion + 1}</span>/{questions.length}
									</div>
									<div className='question-text'>{questions[currentQuestion]?.questionText}</div>
								</div>
								<div className='flex  flex-col '>
									{questions[currentQuestion]?.answerOptions?.map((answerOption) => (
										<button style={btnStyle} className="mb-5" onClick={() => handleAnswerOptionClick(answerOption.isCorrect)}>{answerOption.answerText}</button>
									))}
								</div>
							</>
						)}
						</div>
                    </div>
                </div>
            </div>
            
    );
};

export default Test;