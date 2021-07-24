import React from "react";
import { Button, Item, TextArea } from "semantic-ui-react";

export default function PostComment() {
  return (
    <Item.Group>
      <TextArea
        style={{ width: "45em", height: "7em" }}
        placeholder="Enter your comment"
      />
      <Button primary>Submit</Button>
    </Item.Group>
  );
}
