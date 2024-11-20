import { Quiz } from "../quiz/Quiz";
import { User } from "../user/User";

export type Result = {
  createdAt: Date;
  id: string;
  pass: boolean | null;
  quiz?: Quiz | null;
  score: number | null;
  updatedAt: Date;
  user?: User | null;
};
