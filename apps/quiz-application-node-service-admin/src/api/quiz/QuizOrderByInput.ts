import { SortOrder } from "../../util/SortOrder";

export type QuizOrderByInput = {
  createdAt?: SortOrder;
  endTime?: SortOrder;
  id?: SortOrder;
  name?: SortOrder;
  startTime?: SortOrder;
  status?: SortOrder;
  updatedAt?: SortOrder;
};
