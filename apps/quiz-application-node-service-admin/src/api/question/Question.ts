import { JsonValue } from "type-fest";

export type Question = {
  correctAnswer: JsonValue;
  createdAt: Date;
  id: string;
  options: JsonValue;
  questionText: string | null;
  typeField?: "Option1" | null;
  updatedAt: Date;
};
