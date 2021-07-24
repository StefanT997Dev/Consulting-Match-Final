import { createContext, useContext } from "react";
import CategoryStore from "./categoryStore";
import CommentStore from "./commentStore";
import CommonStore from "./commonStore";
import ConsultantStore from "./consultantStore";
import MessageStore from "./messageStore";
import PostStore from "./postStore";
import ReviewStore from "./reviewStore";
import UserStore from "./userStore";

interface Store{
    consultantStore:ConsultantStore;
    userStore:UserStore;
    reviewStore:ReviewStore;
    commonStore:CommonStore;
    messageStore:MessageStore;
    postStore:PostStore;
    categoryStore:CategoryStore;
    commentStore:CommentStore;
}

export const store:Store = {
    consultantStore: new ConsultantStore(),
    userStore:new UserStore(),
    reviewStore: new ReviewStore(),
    commonStore:new CommonStore(),
    messageStore:new MessageStore(),
    postStore:new PostStore(),
    categoryStore:new CategoryStore(),
    commentStore:new CommentStore()
}

console.log('store', store);

export const StoreContext = createContext(store);

export function useStore(){
    return useContext(StoreContext);
}