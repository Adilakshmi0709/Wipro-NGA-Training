// models/answer.ts
export interface Answer {
  AnswerId: number;
  text: string;
  status: string;
  user?: any;
  question?: any;
  images?: string[];
}
