import { makeAutoObservable } from "mobx";
import { Message } from "../models/message";
import { v4 as uuid } from 'uuid';

export default class MessageStore{
    message:Message | undefined=undefined;

    constructor(){
        makeAutoObservable(this);
    }

    setMessage=(content:string)=>{
        this.message={
            id:uuid(),
            content: content
        }
    }
}
