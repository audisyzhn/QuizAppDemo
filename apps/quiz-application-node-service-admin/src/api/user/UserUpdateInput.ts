import { ResultUpdateManyWithoutUsersInput } from "./ResultUpdateManyWithoutUsersInput";
import { InputJsonValue } from "../../types";

export type UserUpdateInput = {
  email?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  password?: string;
  results?: ResultUpdateManyWithoutUsersInput;
  roles?: InputJsonValue;
  username?: string;
};
