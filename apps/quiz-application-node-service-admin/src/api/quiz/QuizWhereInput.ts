import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { ResultListRelationFilter } from "../result/ResultListRelationFilter";

export type QuizWhereInput = {
  endTime?: DateTimeNullableFilter;
  id?: StringFilter;
  name?: StringNullableFilter;
  results?: ResultListRelationFilter;
  startTime?: DateTimeNullableFilter;
  status?: "Option1";
};
