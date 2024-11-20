import { ResultCreateNestedManyWithoutUsersInput } from "./ResultCreateNestedManyWithoutUsersInput";
import { InputJsonValue } from "../../types";

export type UserCreateInput = {
  email?: string | null;
  firstName?: string | null;
  lastName?: string | null;
  password: string;
  results?: ResultCreateNestedManyWithoutUsersInput;
  roles: InputJsonValue;
  username: string;
};
