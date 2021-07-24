export interface Post{
    id:string,
    title:string,
    description:string | number | undefined,
    picture?:string,
    video?:string,
    numberOfCredits?:number
}