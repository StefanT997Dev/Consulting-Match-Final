import React from "react";
import { Form, Checkbox } from "semantic-ui-react";
import { Field } from "react-final-form";

import "./FieldCheckbox.scss";

type FieldCheckboxProps = {
  name: string;
  label: string;
  value: string;
  validate?: any;
};

const FieldCheckbox: React.FC<FieldCheckboxProps> = (props) => {
  const { name, label, value, validate } = props;
  return (
    <Field
      name={name}
      type="checkbox"
      value={value}
      render={({ input, meta }) => (
        <Form.Field error={meta.error && meta.touched} className="checkbox">
          <input {...input} />
          {meta.error && meta.touched && (
            <span className="checkbox__error">{meta.error}</span>
          )}
          <label className="checkbox__label">{label}</label>
        </Form.Field>
      )}
      validate={validate}
    />
  );
};

export default FieldCheckbox;
