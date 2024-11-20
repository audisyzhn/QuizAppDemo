import { JsonFilter } from "../../util/JsonFilter";
import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";

export type QuestionWhereInput = {
  correctAnswer?: JsonFilter;
  id?: StringFilter;
  options?: JsonFilter;
  questionText?: StringNullableFilter;
  typeField?: "Option1";
};
