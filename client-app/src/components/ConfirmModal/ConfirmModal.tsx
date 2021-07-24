import React from "react";
import { Modal, Button } from "semantic-ui-react";

import "./ConfirmModal.scss";

type ConfirmModalProps = {
  open: boolean;
  deleteMode: boolean;
  onSubmit: any;
  onCancel: any;
  headerText: string;
  descriptionText: string;
  loading: boolean;
};

const ConfirmModal: React.FC<ConfirmModalProps> = (props) => {
  const {
    open,
    deleteMode,
    onSubmit,
    onCancel,
    headerText,
    descriptionText,
    loading,
  } = props;

  return (
    <Modal onClose={onCancel} open={open}>
      <Modal.Header>{headerText}</Modal.Header>
      <Modal.Content>
        <Modal.Description>{descriptionText}</Modal.Description>
      </Modal.Content>
      <Modal.Actions>
        <Button color="black" onClick={onCancel}>
          Cancel
        </Button>
        {deleteMode ? (
          <Button loading={loading} color="red" onClick={onSubmit}>
            Delete
          </Button>
        ) : (
          <Button loading={loading} color="green" onClick={onSubmit}>
            Edit
          </Button>
        )}
      </Modal.Actions>
    </Modal>
  );
};

export default ConfirmModal;
