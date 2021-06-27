import axios, { AxiosError, AxiosResponse } from 'axios';
import { Category } from '../models/category';
import { Consultant } from '../models/consultant';
import { Message } from '../models/message';
import { Post } from '../models/post';
import { Review } from '../models/review';
import { UserFormValues } from '../models/user';
import { toast } from 'react-toastify';
import { history } from '..';
import { request } from 'http';

axios.defaults.baseURL='http://localhost:5000';

axios.interceptors.response.use(async response =>{
    return response;
    // Ako vrati bilo sta sem 200 ide u error
},(error:AxiosError)=>{
  // return { data: { value: {}}};
    const{data,status}=error.response!;
    switch(status){
        case 400:
            if(data.errors){
                const modelStateErrors=[];
                for(const key in data.errors){
                    if(data.errors[key]){
                        modelStateErrors.push(data.errors[key]);
                    }
                }
                throw modelStateErrors.flat();
            }else{
                toast.error(data);
            }
            break;
        case 401:
            toast.error('unauthorized');
            break;
        case 404:
            history.push('/not-found');
            break;
        case 500:
            toast.error('server error');
            break;
    }
    return Promise.reject(error);
})

axios.interceptors.request.use(async request=>{
    console.log(request);
    return request;
})

const responseBody=(response:AxiosResponse) => response.data.value;
const responseBodyForPost=(response:AxiosResponse) => response.data;

const requests = {
    get:(url:string, body:{}) => axios.get(url,body).then(responseBody),
    post:(url:string,body:{}) => axios.post(url,body).then(responseBodyForPost),
    put:(url:string,body:{}) => axios.put(url,body).then(responseBody),
    del:(url:string,body:{}) => axios.delete(url,body).then(responseBody)
}

const Consultants={
    list:()=>requests.get('/consultants',{}),
    postAReview:(selectedConsultant:Consultant | undefined,review:Review | undefined)=>
        requests.post("/consultants/"+selectedConsultant?.id+"/reviews",{starRating:review?.starRating,comment:review?.comment}),
    getListOfReviews:(currentConsultant:Consultant|undefined) => requests.get("/consultants/"+currentConsultant?.id+"/reviews",{}),
    listForSelectedCategory:(selectedCategory:Category | undefined | null)=>requests.get("/categories/"+selectedCategory?.id+"/consultants",{}),
    getListOfPosts:(consultant:Consultant | undefined)=>requests.get("/consultants/"+consultant?.id+"/posts",{}),
    submitAPost:(consultant:Consultant | undefined,post:Post | undefined)=>
        requests.post("/consultants/"+consultant?.id+"/posts",{id:post?.id,title:post?.title,description:post?.description}),
    search:(consultantName:string | undefined)=>requests.post("/consultants",{description:consultantName})
        .then(response=>response.value)
}

const Categories={
    list:()=>requests.get('/categories',{}),
    add:(id: string, name: string)=>requests.post('/categories',{id,name}),
}

const Messages={
    send:(selectedConsultant:Consultant | undefined,message:Message|undefined) => requests.post("/message/"+selectedConsultant?.id,{id:message?.id,content:message?.content})
}

const Account={
    current: ()=>requests.get('/account',{}),
    login: (user:UserFormValues) => requests.post('/account/login',user),
    register:(user:UserFormValues)=>requests.post('/account/register',user)
}

const Admin={
    usersPaginated: (PageNumber: number,PageSize: number) =>axios.get(`/users?PageNumber=${PageNumber}&PageSize=${PageSize}`),
    deleteUser: (email: string) => requests.del('/admin',{email}),
}

const agent={
    Consultants,
    Categories,
    Messages,
    Account,
    Admin
}

export default agent;