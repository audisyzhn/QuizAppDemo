import { ResultUpdateManyWithoutQuizzesInput } from "./ResultUpdateManyWithoutQuizzesInput";

export type QuizUpdateInput = {
  endTime?: Date | null;
  name?: string | null;
  results?: ResultUpdateManyWithoutQuizzesInput;
  startTime?: Date | null;
  status?: "Option1" | null;
};
