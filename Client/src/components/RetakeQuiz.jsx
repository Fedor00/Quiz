import { Button } from "react-bootstrap";

function RetakeQuiz({ retakeQuiz, className }) {
  return (
    <Button onClick={retakeQuiz} variant="dark" className={className}>
      Retake Quiz
    </Button>
  );
}

export default RetakeQuiz;
