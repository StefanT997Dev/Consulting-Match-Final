import { makeAutoObservable } from "mobx";
import {User} from '../models/user';

export default class CommonStore{
    displayConsultantContact:boolean=false;
    token:string|null=window.localStorage.getItem('jwt');
    user:string|null=window.localStorage.getItem('user');
    appLoaded=false;

    constructor(){
        makeAutoObservable(this);

        // reaction(
        //     ()=>
        // )
    }

    getUserObject = ()=>{
        const userObject:User = JSON.parse(this.user!);
        return userObject;
    }

    setDisplayConsultantContact=()=>{
        this.displayConsultantContact=!this.displayConsultantContact;
    }

    setToken=(token:string|null)=>{
        if(token) window.localStorage.setItem('jwt',token);
        this.token=token;
    }

    setUser=(user: User|null)=>{
      if(user) window.localStorage.setItem('user', JSON.stringify(user));
      this.user=JSON.stringify(user);
    }

    setAppLoaded=()=>{
        this.appLoaded=true;
    }
}