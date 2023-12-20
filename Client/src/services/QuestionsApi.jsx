import axios from "axios";

const API_URL = "http://localhost:5265/api/questions";

const fetchQuestionByIdApi = async (id) => {
  try {
    const resp = await axios.get(`${API_URL}/${id}`);
    return resp.data;
  } catch (error) {
    console.log(error);
  }
};
const fetchQuestions = async () => {
  try {
    const resp = await axios.get(`${API_URL}}`);
    return resp.data;
  } catch (error) {
    console.log(error);
  }
};
export { fetchQuestionByIdApi, fetchQuestions };
