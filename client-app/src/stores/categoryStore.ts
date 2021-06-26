import { makeAutoObservable } from "mobx";
import { MenuItemProps } from "semantic-ui-react";
import agent from "../api/agent";

export default class CategoryStore{
    activeCategoryName:string|undefined='';

    constructor(){
        makeAutoObservable(this);
    }    

    handleActiveCategoryName = (event:React.MouseEvent<HTMLAnchorElement, MouseEvent>,data:MenuItemProps) =>{
        this.activeCategoryName=data.name;
    }

    addCategory = async(id: string, name: string) => {
      try {
        const category = await agent.Categories.add(id, name);
      } catch(error) {
        throw error;
      }
    }
}