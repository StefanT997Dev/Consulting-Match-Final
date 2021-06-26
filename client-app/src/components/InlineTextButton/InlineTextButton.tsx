import React from "react";
import classNames from "classnames";

import "./InlineTextButton.scss";

type InlineTextButtonProps = {
  onClick: any;
  className?: string;
};

const InlineTextButton: React.FC<InlineTextButtonProps> = (props) => {
  const { className, onClick, children } = props;

  const classes = classNames("inline-text-button" || className);

  return (
    <button
      className={classes}
      onClick={(e) => {
        e.preventDefault();
        onClick();
      }}
    >
      {children}
    </button>
  );
};

export default InlineTextButton;
