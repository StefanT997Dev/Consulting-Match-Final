import { makeAutoObservable, runInAction } from "mobx";
import { MenuItemProps } from "semantic-ui-react";
import { history } from "..";
import agent from "../api/agent";
import { Category } from "../models/category";

export default class CategoryStore{
    activeCategoryName:string|undefined='';
    selectedCategoryId:string|undefined="";
    chosenCategory:string|undefined='';

    constructor(){
        makeAutoObservable(this);
    }    

    setChosenCategory=(categoryName:string|undefined)=>{
      this.chosenCategory=categoryName;
    }

    handleActiveCategoryName = (event:React.MouseEvent<HTMLAnchorElement, MouseEvent>,data:MenuItemProps) =>{
        this.activeCategoryName=data.name;
    }

    setSelectedCategory= async (categoryId:string|undefined)=>{
      runInAction(()=>this.selectedCategoryId=categoryId);
      await agent.Categories.details(categoryId).then((response)=>{
        runInAction(()=>this.chosenCategory=response.name);
      });
    }

    getSelectedCategoryId=()=>{
      return this.selectedCategoryId;
    }

    addCategory = async(id: string | undefined, name: string) => {
      try {
        debugger
        const response = await agent.Categories.add(id, name);
        return response;
      } catch(error) {
        throw error;
      }
    }

    chooseCategory=async(consultantId:string | undefined,categoryId:string)=>{
      await agent.Categories.choose(consultantId,categoryId);
      history.push('/skills');
    }
}