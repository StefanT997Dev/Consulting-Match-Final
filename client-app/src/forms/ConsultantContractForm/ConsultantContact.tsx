import React, { useState } from "react";
import {
  Button,
  Form,
  FormProps,
  InputOnChangeData,
  Segment,
} from "semantic-ui-react";
import agent from "../../api/agent";
import { useStore } from "../../stores/store";

export default function ConsultantContactForm() {
  const { consultantStore } = useStore();
  const { messageStore } = useStore();
  const [message, setMessage] = useState<string>("");

  const handleChangedMessage = (
    event: React.ChangeEvent<HTMLInputElement>,
    data: InputOnChangeData
  ) => {
    setMessage(data.value);
  };

  const sendMessage = (
    event: React.FormEvent<HTMLFormElement>,
    data: FormProps
  ) => {
    messageStore.setMessage(message);
    agent.Messages.send(
      consultantStore.selectedConsultant,
      messageStore.message
    );
  };

  return (
    <Segment clearing>
      <Form onSubmit={sendMessage}>
        <Form.Input
          placeholder="Type your message here..."
          onChange={handleChangedMessage}
        />
        <Button floated="right" positive type="submit" content="Send" />
      </Form>
    </Segment>
  );
}
