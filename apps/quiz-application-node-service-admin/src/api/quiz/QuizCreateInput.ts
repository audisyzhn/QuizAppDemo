import { ResultCreateNestedManyWithoutQuizzesInput } from "./ResultCreateNestedManyWithoutQuizzesInput";

export type QuizCreateInput = {
  endTime?: Date | null;
  name?: string | null;
  results?: ResultCreateNestedManyWithoutQuizzesInput;
  startTime?: Date | null;
  status?: "Option1" | null;
};
