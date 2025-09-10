// models/question.ts
export interface Question {
  QuestionId: number;
  title: string;
  text: string;
  status: string;
  user?: any;
  images?: string[];
  answers?: any[];
}
