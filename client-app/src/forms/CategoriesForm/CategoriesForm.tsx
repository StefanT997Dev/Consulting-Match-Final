import React, { useState, useEffect } from "react";
import {
  Container,
  Button,
  Dimmer,
  Header,
  Form,
  Loader,
} from "semantic-ui-react";
import { Form as FinalForm } from "react-final-form";
import { Category } from "../../models/category";
import InlineTextButton from "../../components/InlineTextButton/InlineTextButton";
import FieldRadioButton from "../../components/FieldRadioButton/FieldRadioButton";
import FieldTextInput from "../../components/FieldTextInput/FieldTextInput";
import { required } from "../../util/validators";
import { useStore } from "../../stores/store";
import agent from "../../api/agent";

import "./CategoriesForm.scss";

type CategoriesForm = {};

const CategoriesForm: React.FC<CategoriesForm> = (props) => {
  // categories
  const [categories, setCategories] = useState<Category[]>([]);
  const [fetchCategoriesInProgress, setFetchCategoriesInProgress] =
    useState<boolean>(false);
  const [fetchCategoriesError, setFetchCategoriesError] = useState<string>("");
  // add new category
  const [isOpenNewCategory, setIsOpenNewCategory] = useState<boolean>(false);
  const [addCategoryInProgress, setAddCategoryInProgress] =
    useState<boolean>(false);
  const [addCategoryError, setAddCategoryError] = useState<string>("");

  const { userStore, categoryStore } = useStore();
  console.log(userStore.user);

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        setFetchCategoriesInProgress(true);
        setFetchCategoriesError("");
        const response = await agent.Categories.list();
        setCategories(response);
      } catch (error) {
        setFetchCategoriesError("An error occurred while fetching categories.");
      } finally {
        setFetchCategoriesInProgress(false);
      }
    };
    fetchCategories();
  }, []);

  const addNewCategory = async (name: string) => {
    //TODO: need to check with Stefan to retrieve userId with other user data
    // when logging in or register
    return;
    try {
      setAddCategoryInProgress(true);
      setAddCategoryError("");
      await categoryStore.addCategory("id", name);
      setIsOpenNewCategory(false);
    } catch (e) {
      setAddCategoryError(e.toString());
    } finally {
      setAddCategoryInProgress(false);
    }
  };

  return fetchCategoriesInProgress ? (
    <Dimmer active inverted>
      <Loader inverted>Loading categories...</Loader>
    </Dimmer>
  ) : fetchCategoriesError ? (
    <div className="categories-form__form__error">{fetchCategoriesError}</div>
  ) : (
    <Container textAlign="center" className="categories-form">
      <div className="categories-form__form">
        <FinalForm
          onSubmit={(values: any) => console.log("values", values)}
          render={({ handleSubmit, valid, values, submitting }) => (
            <Form onSubmit={handleSubmit}>
              <Header as="h1">Choose category</Header>
              <div className="categories-form__form__grouped-items">
                {categories.map((c) => (
                  <FieldRadioButton
                    key={c.id}
                    name="categoryId"
                    value={c.id}
                    label={c.name}
                    validate={required("You must select atlest one category.")}
                  />
                ))}
              </div>
              {isOpenNewCategory ? (
                <div>
                  <hr></hr>
                  <FieldTextInput
                    name="name"
                    type="text"
                    label="Category name"
                    placeholder="Enter category name..."
                    validate={required("Category name is required.")}
                  />
                  <Button
                    type="secondary"
                    loading={addCategoryInProgress}
                    positive
                    content="Add category"
                    onClick={() => {
                      const { name } = values;
                      if (name) {
                        addNewCategory(name);
                      }
                    }}
                  />
                  <hr></hr>
                </div>
              ) : (
                <div className="categories-form__form__inline-button-container">
                  <InlineTextButton onClick={() => setIsOpenNewCategory(true)}>
                    + Add new category
                  </InlineTextButton>
                </div>
              )}
              <Button
                disabled={!valid}
                loading={submitting}
                positive
                content="Choose category"
                type="submit"
                fluid
              />
            </Form>
          )}
        />
      </div>
    </Container>
  );
};

export default CategoriesForm;
