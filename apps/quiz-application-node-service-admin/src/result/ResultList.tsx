import * as React from "react";

import {
  List,
  Datagrid,
  ListProps,
  DateField,
  TextField,
  BooleanField,
  ReferenceField,
} from "react-admin";

import Pagination from "../Components/Pagination";
import { QUIZ_TITLE_FIELD } from "../quiz/QuizTitle";
import { USER_TITLE_FIELD } from "../user/UserTitle";

export const ResultList = (props: ListProps): React.ReactElement => {
  return (
    <List {...props} title={"Results"} perPage={50} pagination={<Pagination />}>
      <Datagrid rowClick="show" bulkActionButtons={false}>
        <DateField source="createdAt" label="Created At" />
        <TextField label="ID" source="id" />
        <BooleanField label="pass" source="pass" />
        <ReferenceField label="Quiz" source="quiz.id" reference="Quiz">
          <TextField source={QUIZ_TITLE_FIELD} />
        </ReferenceField>
        <TextField label="score" source="score" />
        <DateField source="updatedAt" label="Updated At" />
        <ReferenceField label="User" source="user.id" reference="User">
          <TextField source={USER_TITLE_FIELD} />
        </ReferenceField>{" "}
      </Datagrid>
    </List>
  );
};
