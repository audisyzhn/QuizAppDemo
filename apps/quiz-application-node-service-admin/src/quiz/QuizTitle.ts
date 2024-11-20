import { Quiz as TQuiz } from "../api/quiz/Quiz";

export const QUIZ_TITLE_FIELD = "name";

export const QuizTitle = (record: TQuiz): string => {
  return record.name?.toString() || String(record.id);
};
