import { Skill } from "./skill";

export interface ConsultantSearchDto{
    displayName:string;
    skills:Skill[];
}