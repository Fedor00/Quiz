import { Badge, Card, Container } from "react-bootstrap";
import Choices from "./Choices";
import style from "./Question.module.css";
function Question({ question, onChoiceSelected, score, showScore }) {
  return (
    <Container
      className="d-flex align-items-center justify-content-center"
      style={{ height: "100vh" }}
    >
      <Card bg="secondary" className="text-center flex-grow-1 ">
        <Card.Header className="h3">{question?.text}</Card.Header>
        <Card.Body>
          <Choices
            onChoiceSelected={onChoiceSelected}
            choices={question?.choices}
          />
        </Card.Body>
        <Card.Footer className="h3">
          {showScore && (
            <Badge bg="dark" className={style.score}>
              Score: {score}
            </Badge>
          )}
        </Card.Footer>
      </Card>
    </Container>
  );
}

export default Question;
