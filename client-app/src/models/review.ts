import { Consultant } from "./consultant";

export interface Review{
    id:string;
    starRating:number | string | undefined;
    comment: string | number | undefined;
    consultant?:Consultant;
}