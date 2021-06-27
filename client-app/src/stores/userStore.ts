import { makeAutoObservable, runInAction } from "mobx";
import { history } from "..";
import agent from "../api/agent";
import { User, UserFormValues } from "../models/user";
import { store } from "./store";

export default class UserStore{
    user:User | null = null;

    constructor(){
        makeAutoObservable(this)
    }

    get isLoggedIn(){
        return !!this.user;
    }

    getUsersPaginated=async(PageNumber: number, PageSize: number)=>{
      return await agent.Admin.usersPaginated(PageNumber, PageSize);
    }

    deleteUser=async(email: string)=>{
      return await agent.Admin.deleteUser(email);
    }

    login = async(creds:UserFormValues)=>{
        try{
            const user=await agent.Account.login(creds);
            store.commonStore.setToken(user.token);
            store.commonStore.setUser(user);
            runInAction(()=>this.user=user);
            history.push('/consultants');
        }catch(error){
            throw error;
        }
    }

    logout=()=>{
        store.commonStore.setToken(null);
        window.localStorage.removeItem('jwt');
        this.user=null;
        history.push('/');
    }

    register = async(creds: UserFormValues) => {
      try {
        const user = await agent.Account.register(creds);
        console.log('register', user);
        store.commonStore.setToken(user.token);
        store.commonStore.setUser(user);
        runInAction(()=>this.user=user);
      }catch(error) {
        throw error;
      }
    }
}