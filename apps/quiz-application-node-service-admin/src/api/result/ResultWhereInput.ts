import { StringFilter } from "../../util/StringFilter";
import { BooleanNullableFilter } from "../../util/BooleanNullableFilter";
import { QuizWhereUniqueInput } from "../quiz/QuizWhereUniqueInput";
import { FloatNullableFilter } from "../../util/FloatNullableFilter";
import { UserWhereUniqueInput } from "../user/UserWhereUniqueInput";

export type ResultWhereInput = {
  id?: StringFilter;
  pass?: BooleanNullableFilter;
  quiz?: QuizWhereUniqueInput;
  score?: FloatNullableFilter;
  user?: UserWhereUniqueInput;
};
