import React, { useState } from "react";
import { observer } from "mobx-react-lite";
import { Container, Header, Button, Form } from "semantic-ui-react";
import FieldTextInput from "../../components/FieldTextInput/FieldTextInput";
import { Form as FinalForm } from "react-final-form";
import { useStore } from "../../stores/store";
import {
  composeValidators,
  emailFormatValid,
  minLength,
  required,
} from "../../util/validators";

import "./LoginForm.scss";

export default observer(function LoginForm() {
  const [error, setError] = useState<string>("");
  const { userStore } = useStore();
  return (
    <Container textAlign="center" className="login-form">
      <div className="login-form__form">
        <FinalForm
          onSubmit={(values: any) =>
            userStore
              .login(values)
              .then(() => setError(""))
              .catch(() => setError("Invalid email or password"))
          }
          render={({ handleSubmit, valid, submitting }) => (
            <Form onSubmit={handleSubmit}>
              <Header as="h1">Login</Header>
              <FieldTextInput
                name="email"
                type="email"
                placeholder="Enter email..."
                validate={composeValidators(
                  required("Email is required"),
                  emailFormatValid("Please enter valid email")
                )}
              />
              <FieldTextInput
                name="password"
                type="password"
                placeholder="Enter password..."
                validate={composeValidators(
                  required("Password is required."),
                  minLength("Minimum password length is 8", 8)
                )}
              />
              <Button
                disabled={!valid}
                loading={submitting}
                positive
                content="Login"
                type="submit"
                fluid
              />
              <div className="login-form__form__error">{error}</div>
            </Form>
          )}
        ></FinalForm>
      </div>
    </Container>
  );
});
