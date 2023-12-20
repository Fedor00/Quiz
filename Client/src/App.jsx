import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import QuizPage from "./pages/QuizPage";
import AnimatedBackground from "./components/AnimatedBackground";
function App() {
  return (
    <>
      <AnimatedBackground />
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<QuizPage />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App;
