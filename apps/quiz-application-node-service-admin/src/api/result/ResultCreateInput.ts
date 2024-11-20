import { QuizWhereUniqueInput } from "../quiz/QuizWhereUniqueInput";
import { UserWhereUniqueInput } from "../user/UserWhereUniqueInput";

export type ResultCreateInput = {
  pass?: boolean | null;
  quiz?: QuizWhereUniqueInput | null;
  score?: number | null;
  user?: UserWhereUniqueInput | null;
};
