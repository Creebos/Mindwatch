import { Answer, Question, Questionnaire, QuestionnaireRun } from "../models/models";
import apiClient from "./http";

export const QuestionnaireAPI = {
  async getAllQuestionnaires(): Promise<Questionnaire[]> {
    const response = await apiClient.get("/questionnaires");
    return response.data as Questionnaire[];
  },

  async getQuestionnaireById(id: number): Promise<Questionnaire> {
    const response = await apiClient.get(`/questionnaires/${id}`);
    return response.data as Questionnaire;
  },

  async createQuestionnaire(questionnaire: Questionnaire): Promise<Questionnaire> {
    const response = await apiClient.post("/questionnaires", questionnaire);
    return response.data as Questionnaire;
  },

  async getQuestionnaireRunById(id: number): Promise<QuestionnaireRun> {
    const response = await apiClient.get(`/questionnaires/questionnaire-runs/${id}`);
    return response.data as QuestionnaireRun;
  },

  async createOrUpdateQuestionnaireRun(run: QuestionnaireRun): Promise<QuestionnaireRun> {
    const response = await apiClient.post("/questionnaires/questionnaire-runs", run);
    return response.data as QuestionnaireRun;
  },

  async submitAnswer(answer: Answer): Promise<Answer> {
    const response = await apiClient.post("/questionnaires/answers", answer);
    return response.data as Answer;
  },

  async CreateOrUpdateQuestion(question: Question): Promise<Question> {
    const response = await apiClient.post("/questionnaires/questions", question);
    return response.data as Question;
  },
};
