import { InputJsonValue } from "../../types";

export type QuestionUpdateInput = {
  correctAnswer?: InputJsonValue;
  options?: InputJsonValue;
  questionText?: string | null;
  typeField?: "Option1" | null;
};
