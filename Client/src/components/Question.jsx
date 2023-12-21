import { Badge, Card, Container } from "react-bootstrap";
import Choices from "./Choices";
import style from "./Question.module.css";
import RetakeQuiz from "./RetakeQuiz";
function Question({
  question,
  onChoiceSelected,
  score,
  showScore,
  questionIndex,
  retakeQuiz,
}) {
  return (
    <Container
      className="d-flex align-items-center justify-content-center"
      style={{ height: "100vh" }}
    >
      <Card bg="secondary" className="text-center flex-grow-1 ">
        <Card.Header className="h3">
          <Badge bg="dark" className={style.questionIndex}>
            {questionIndex + 1} / 50
          </Badge>
          {question?.text}
        </Card.Header>
        <Card.Body>
          <Choices
            onChoiceSelected={onChoiceSelected}
            choices={question?.choices}
          />
        </Card.Body>
        <Card.Footer className="h3">
          {showScore && (
            <div className={style.scoreRetake}>
              <Badge bg="dark" className={style.score}>
                Score: {score}
              </Badge>
              <RetakeQuiz retakeQuiz={retakeQuiz} className={style.retake} />
            </div>
          )}
        </Card.Footer>
      </Card>
    </Container>
  );
}

export default Question;
