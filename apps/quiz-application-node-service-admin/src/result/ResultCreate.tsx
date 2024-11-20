import * as React from "react";

import {
  Create,
  SimpleForm,
  CreateProps,
  BooleanInput,
  ReferenceInput,
  SelectInput,
  NumberInput,
} from "react-admin";

import { QuizTitle } from "../quiz/QuizTitle";
import { UserTitle } from "../user/UserTitle";

export const ResultCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <BooleanInput label="pass" source="pass" />
        <ReferenceInput source="quiz.id" reference="Quiz" label="Quiz">
          <SelectInput optionText={QuizTitle} />
        </ReferenceInput>
        <NumberInput label="score" source="score" />
        <ReferenceInput source="user.id" reference="User" label="User">
          <SelectInput optionText={UserTitle} />
        </ReferenceInput>
      </SimpleForm>
    </Create>
  );
};
