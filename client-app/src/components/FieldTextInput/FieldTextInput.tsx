import React from "react";
import { Form } from "semantic-ui-react";
import { Field } from "react-final-form";

import "./FieldTextInput.scss";

type FieldTextInputProps = {
  placeholder: string;
  name: string;
  type?: string;
  label?: string;
  validate?: any;
};

const FieldTextInput: React.FC<FieldTextInputProps> = (props) => {
  const { placeholder, name, type, label, validate } = props;
  return (
    <Field
      name={name}
      render={({ input, meta }) => (
        <Form.Field error={meta.error && meta.touched}>
          <label className="text-input__label">{label}</label>
          <input {...input} type={type} placeholder={placeholder} />
          {meta.error && meta.touched && (
            <span className="text-input__error">{meta.error}</span>
          )}
        </Form.Field>
      )}
      validate={validate}
    />
  );
};

export default FieldTextInput;
