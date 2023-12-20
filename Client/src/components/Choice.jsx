import { Card } from "react-bootstrap";
import style from "./Choice.module.css";
function Choice({ choice, onChoiceSelected }) {
  return (
    <Card
      className={style.choice}
      bg="dark"
      text="white"
      onClick={() => onChoiceSelected(choice)}
    >
      <Card.Body className="h4">{choice?.text}</Card.Body>
    </Card>
  );
}

export default Choice;
