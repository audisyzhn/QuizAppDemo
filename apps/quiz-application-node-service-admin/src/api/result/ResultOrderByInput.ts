import { SortOrder } from "../../util/SortOrder";

export type ResultOrderByInput = {
  createdAt?: SortOrder;
  id?: SortOrder;
  pass?: SortOrder;
  quizId?: SortOrder;
  score?: SortOrder;
  updatedAt?: SortOrder;
  userId?: SortOrder;
};
