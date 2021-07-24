import { makeAutoObservable } from 'mobx';
import agent from '../api/agent';
import { Consultant } from '../models/consultant';
import { Post } from '../models/post';
import { v4 as uuid } from 'uuid';

export default class PostStore{
    posts:Post[]=[];
    post:Post | undefined=undefined;
    errors:string[] | null=null;

    constructor(){
        makeAutoObservable(this);
    }

    getListOfPostsForSelectedConsultant= async (consultant:Consultant | undefined)=>{
        var posts:Post[]=await agent.Consultants.getListOfPosts(consultant);

        posts.forEach(post => {
            this.posts.push(post);
        });

        console.log(posts);
    }

    setPost=(postTitle:string,postDescription:string | number | undefined)=>{
        this.post={id:uuid(),title:postTitle,description:postDescription};
        this.posts.push(this.post);
    }    

    submitAPost=async(consultant:Consultant | undefined,post:Post | undefined)=>{
        debugger
        await agent.Consultants.submitAPost(consultant,post).catch(errors=>this.errors=errors);
        console.log(post);
    }
}