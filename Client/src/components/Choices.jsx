import { Container } from "react-bootstrap";
import Choice from "./Choice";

function Choices({ choices, onChoiceSelected }) {
  return (
    <Container>
      {choices?.map((choice, index) => (
        <Choice
          onChoiceSelected={onChoiceSelected}
          key={index}
          choice={choice}
        />
      ))}
    </Container>
  );
}

export default Choices;
