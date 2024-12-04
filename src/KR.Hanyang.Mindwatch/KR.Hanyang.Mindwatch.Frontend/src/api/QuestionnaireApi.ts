import { Answer } from "../models/Answer";
import { Question } from "../models/Question";
import { Questionnaire } from "../models/Questionnaire";
import { QuestionnaireRun } from "../models/QuestionnaireRun";
import apiClient from "./http";

export const QuestionnaireAPI = {
  async getAllQuestionnaires(): Promise<Questionnaire[]> {
    const response = await apiClient.get("/api/questionnaires");
    return response.data.$values as Questionnaire[];
  },

  async getQuestionnaireById(id: number): Promise<Questionnaire> {
    const response = await apiClient.get(`/api/questionnaires/${id}`);
    return response.data as Questionnaire;
  },

  async createQuestionnaire(questionnaire: Questionnaire): Promise<Questionnaire> {
    const response = await apiClient.post("/api/questionnaires", questionnaire);
    return response.data as Questionnaire;
  },

  async getQuestionnaireRunById(id: number): Promise<QuestionnaireRun> {
    const response = await apiClient.get(`/api/questionnaires/questionnaire-runs/${id}`);
    return response.data as QuestionnaireRun;
  },

  async createQuestionnaireRun(run: QuestionnaireRun): Promise<QuestionnaireRun> {
    const response = await apiClient.post("/api/questionnaires/questionnaire-runs", run);
    return response.data as QuestionnaireRun;
  },

  async submitAnswer(answer: Answer): Promise<Answer> {
    const response = await apiClient.post("/api/questionnaires/answers", answer);
    return response.data as Answer;
  },

  async addQuestion(question: Question): Promise<Question> {
    const response = await apiClient.post("/api/questionnaires/questions", question);
    return response.data as Question;
  },
};
