import { useEffect, useState } from "react";
import { Container } from "react-bootstrap";
import { fetchQuestionByIdApi } from "../services/QuestionsApi";
import Question from "./Question";
const numbers = Array.from({ length: 50 }, (_, index) => index + 1);

const randomizedNumbers = numbers.sort(() => Math.random() - 0.5);

function Quiz() {
  const [questionIndex, setQuestionIndex] = useState(0);
  const [question, setQuestion] = useState({});
  const [score, setScore] = useState(0);
  const [showScore, setShowScore] = useState(false);

  function onChoiceSelected(choiceSelected) {
    if (questionIndex == 49) setShowScore(true);
    else {
      setScore((prev) => (isChoiceCorect(choiceSelected) ? prev + 2 : prev));
      setQuestionIndex((prev) => (prev == 49 ? prev : prev + 1));
    }
  }
  function isChoiceCorect(choiceSelected) {
    return choiceSelected?.text == question?.answer?.correctChoice?.text;
  }

  useEffect(() => {
    const getQuestions = async () => {
      try {
        const questionData = await fetchQuestionByIdApi(
          randomizedNumbers[questionIndex]
        );
        setQuestion(questionData);
        console.log(questionData);
      } catch (error) {
        console.log(error);
      }
    };
    getQuestions();
  }, [questionIndex]);

  return (
    <Container>
      <Question
        onChoiceSelected={onChoiceSelected}
        question={question}
        score={score}
        showScore={showScore}
      />
    </Container>
  );
}

export default Quiz;
