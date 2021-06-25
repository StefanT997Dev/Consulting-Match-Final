import React from "react";
import { Form } from "semantic-ui-react";
import { Field } from "react-final-form";

import "./FieldRadioButton.scss";

type FieldRadioButtonProps = {
  name: string;
  label: string;
  value: string;
  validate?: any;
};

const FieldRadioButton: React.FC<FieldRadioButtonProps> = (props) => {
  const { name, label, value, validate } = props;
  return (
    <label>
      <Field
        name={name}
        component="input"
        type="radio"
        value={value}
        validate={validate}
      />{" "}
      {label}
    </label>
  );
};

export default FieldRadioButton;
