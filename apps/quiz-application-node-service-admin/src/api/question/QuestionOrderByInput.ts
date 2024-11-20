import { SortOrder } from "../../util/SortOrder";

export type QuestionOrderByInput = {
  correctAnswer?: SortOrder;
  createdAt?: SortOrder;
  id?: SortOrder;
  options?: SortOrder;
  questionText?: SortOrder;
  typeField?: SortOrder;
  updatedAt?: SortOrder;
};
