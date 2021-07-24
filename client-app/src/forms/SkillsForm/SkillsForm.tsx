import React, { useEffect, useState } from "react";
import { Form as FinalForm } from "react-final-form";
import { Header, Form, Container, Button, ButtonProps } from "semantic-ui-react";
import { history } from "../..";
import agent from "../../api/agent";
import { Skill } from "../../models/skill";
import { useStore } from "../../stores/store";
import "./SkillsForm.scss";

export default function SkillsForm() {
  const { commonStore,categoryStore } = useStore();
  const [skillsForSelectedCategory,setSkillsForSelectedCategory]=useState<Skill[]>([]);

  useEffect(() => {
    const fetchSkillsForSelectedCategory=async()=>{
      return await agent.Skills.list(categoryStore.getSelectedCategoryId()).then((response)=>{
        setSkillsForSelectedCategory(response);
      });
    }
    fetchSkillsForSelectedCategory();
    skillsForSelectedCategory.forEach(skill => skill.isChosenByConsultant=false);
  }, []);

  const setChosenByConsultantForSkill = (event: React.MouseEvent<HTMLButtonElement, MouseEvent>, data: ButtonProps)=>{
    for(let i in skillsForSelectedCategory){
      if(skillsForSelectedCategory[i].name===data.children){
        skillsForSelectedCategory[i].isChosenByConsultant=!skillsForSelectedCategory[i].isChosenByConsultant;
      }
    }
    const copy=[...skillsForSelectedCategory];
    setSkillsForSelectedCategory(copy);
  }

  const chooseSkillsForConsultant=()=>{
    agent.Skills.choose(skillsForSelectedCategory.filter(skill => skill.isChosenByConsultant===true),commonStore.token!);
    history.push('/profile');
  }
  
  return (
    <Container textAlign="center" className="skills-form">
      <div className="skills-form__form">
        <FinalForm
          onSubmit={() => console.log("sdsdsd")}
          render={({ handleSubmit, valid, values, submitting }) => (
            <Form onSubmit={() => console.log("ssd")}>
              <Header as="h1">
                Select skills you possess for the {categoryStore.chosenCategory?categoryStore.chosenCategory:null} category
              </Header>
              {skillsForSelectedCategory.map((skill) => (
                  <Button active={skill.isChosenByConsultant===true} onClick={setChosenByConsultantForSkill} circular key={skill.id} toggle>{skill.name}</Button>
              ))}
              <Button style={{"marginTop":"2em"}} primary size='large' onClick={chooseSkillsForConsultant}>Submit</Button>
            </Form>
          )}
        />
      </div>
    </Container>
  )
};
