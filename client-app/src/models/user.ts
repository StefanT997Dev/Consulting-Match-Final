export interface User{
    id?: string,
    username?:string;
    displayName:string;
    email?:string;
    token?:string;
    image?:string;
}

export interface UserFormValues{
    email:string;
    password:string;
    displayName?:string,
    username?:string;
}