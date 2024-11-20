import { QuizWhereUniqueInput } from "./QuizWhereUniqueInput";
import { QuizUpdateInput } from "./QuizUpdateInput";

export type UpdateQuizArgs = {
  where: QuizWhereUniqueInput;
  data: QuizUpdateInput;
};
