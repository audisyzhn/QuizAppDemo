import { InputJsonValue } from "../../types";

export type QuestionCreateInput = {
  correctAnswer?: InputJsonValue;
  options?: InputJsonValue;
  questionText?: string | null;
  typeField?: "Option1" | null;
};
