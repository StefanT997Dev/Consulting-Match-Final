import React, { useState, useEffect } from "react";
import {
  Button,
  Container,
  Dimmer,
  Form,
  Header,
  Loader,
} from "semantic-ui-react";
import { Form as FinalForm, Field } from "react-final-form";
import FieldTextInput from "../../components/FieldTextInput/FieldTextInput";
import FieldCheckbox from "../../components/FieldCheckbox/FieldCheckbox";
import FieldRadioButton from "../../components/FieldRadioButton/FieldRadioButton";
import {
  composeValidators,
  emailFormatValid,
  minLength,
  required,
} from "../../util/validators";
import agent from "../../api/agent";
import { Category } from "../../models/category";
import { useStore } from "../../stores/store";
import { roles } from "../../constants";

import "./RegisterForm.scss";

export default function RegisterForm() {
  const [error, setError] = useState<string>("");
  const [categories, setCategories] = useState<Category[]>([]);
  const [fetchCategoriesInProgress, setFetchCategoriesInProgress] =
    useState<boolean>(false);
  const [fetchCategoriesError, setFetchCategoriesError] = useState<string>("");
  const { userStore } = useStore();

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        setFetchCategoriesInProgress(true);
        setFetchCategoriesError("");
        const response = await agent.Categories.list();
        setCategories(response);
      } catch {
        setFetchCategoriesError("An error occurred while fetching categories.");
      } finally {
        setFetchCategoriesInProgress(false);
      }
    };
    fetchCategories();
  }, []);

  return (
    <Container textAlign="center" className="register-form">
      <div className="register-form__form">
        <FinalForm
          onSubmit={(
            values: any //console.log(values)
          ) =>
            userStore
              .register(values)
              .then(() => setError(""))
              .catch(() => setError("Email or username already taken"))
          }
          render={({ handleSubmit, valid, values, submitting }) => (
            <Form onSubmit={handleSubmit}>
              <Header as="h1">Register</Header>
              <FieldTextInput
                name="displayName"
                type="text"
                label="Display name"
                placeholder="Enter display name..."
                validate={required("Display name is required.")}
              />
              <FieldTextInput
                name="userName"
                type="text"
                label="User name"
                placeholder="Enter user name..."
                validate={required("User name is required.")}
              />
              <FieldTextInput
                name="email"
                type="email"
                label="Email"
                placeholder="Enter email..."
                validate={composeValidators(
                  required("Email is required"),
                  emailFormatValid("Please enter valid email")
                )}
              />
              <FieldTextInput
                name="password"
                type="password"
                label="Password"
                placeholder="Enter password..."
                validate={composeValidators(
                  required("Password is required."),
                  minLength("Minimum password length is 8", 8)
                )}
              />
              <div className="register-form__form__grouped-items">
                <label className="register-form__form__label">Role</label>
                {roles.map((role) => (
                  <FieldRadioButton
                    name="role"
                    value={role.value}
                    label={role.text}
                    validate={required("You must select role.")}
                  />
                ))}
              </div>
              {values.role === "consultant" &&
                (fetchCategoriesInProgress ? (
                  <Dimmer active inverted>
                    <Loader inverted>Loading categories...</Loader>
                  </Dimmer>
                ) : fetchCategoriesError ? (
                  <div className="register-form__form__error">
                    {fetchCategoriesError}
                  </div>
                ) : (
                  <div>
                    <hr></hr>
                    <label className="register-form__form__label">
                      Select Category
                    </label>
                    <div className="register-form__form__grouped-items">
                      {categories.map((c) => (
                        <FieldCheckbox
                          key={c.id}
                          name="category"
                          value={c.name}
                          label={c.name}
                          validate={required(
                            "You must select atlest one category."
                          )}
                        />
                      ))}
                    </div>
                    <hr></hr>
                  </div>
                ))}
              <div className={"register-form__form__termsAndConditions"}>
                <label className="register-form__form__label">
                  Terms and conditions
                </label>
                <FieldCheckbox
                  name="termsAndConditions"
                  value="agreed"
                  label="I agree to the Terms and Conditions"
                  validate={required("Terms and conditions are required.")}
                />
              </div>
              <Button
                disabled={!valid}
                loading={submitting}
                positive
                content="Register"
                type="submit"
                fluid
              />
              <div className="register-form__form__error">{error}</div>
            </Form>
          )}
        />
      </div>
    </Container>
  );
}
