import { Result } from "../result/Result";

export type Quiz = {
  createdAt: Date;
  endTime: Date | null;
  id: string;
  name: string | null;
  results?: Array<Result>;
  startTime: Date | null;
  status?: "Option1" | null;
  updatedAt: Date;
};
