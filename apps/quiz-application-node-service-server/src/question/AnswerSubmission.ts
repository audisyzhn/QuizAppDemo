import { ArgsType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import { Type } from "class-transformer";
import { GraphQLJSON } from "graphql-type-json";
import { InputJsonValue } from "../types";

@ArgsType()
class AnswerSubmission {
    @Field(() => String)
    @ApiProperty({
        required: true,
        type: () => String
    })
    @Type(() => String)
    quizId!: string;

    @Field(() => [GraphQLJSON])
    answers!: InputJsonValue;
}

export { AnswerSubmission as AnswerSubmission };