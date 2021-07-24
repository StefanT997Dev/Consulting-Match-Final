import { observer } from "mobx-react-lite";
import React, { useState } from "react";
import { Link, NavLink } from "react-router-dom";
import {
  Button,
  Card,
  Form,
  Image,
  Message,
  Rating,
  RatingProps,
  TextAreaProps,
} from "semantic-ui-react";
import { useStore } from "../../stores/store";

export default observer(function ConsultantDetails() {
  const { consultantStore } = useStore();
  const { selectedConsultant } = consultantStore;
  const { commonStore } = useStore();

  const [starRating, setStarReviewForSelectedConsultant] =
    useState<number | string | undefined>(0);
  const [comment, setTextReviewForSelectedConsultant] =
    useState<string | number | undefined>(undefined);

  const rateAConsultant = (
    event: React.MouseEvent<HTMLDivElement, MouseEvent>,
    data: RatingProps
  ) => {
    setStarReviewForSelectedConsultant(data.rating);
  };

  const handleOnChangeTextReview = (
    event: React.ChangeEvent<HTMLTextAreaElement>,
    data: TextAreaProps
  ) => {
    setTextReviewForSelectedConsultant(data.value);
  };

  return (
    <Card fluid>
      <Image src={selectedConsultant?.image} />
      <Card.Content>
        <Card.Header>{selectedConsultant?.displayName}</Card.Header>
        <Card.Meta>
          <span>{selectedConsultant?.bio}</span>
        </Card.Meta>
        <Card.Description>
          {selectedConsultant?.averageStarReview}
        </Card.Description>
      </Card.Content>
      <Rating
        icon="star"
        defaultRating={0}
        maxRating={5}
        onRate={(event, rating) => rateAConsultant(event, rating)}
        size="huge"
      />
      <Form
        onSubmit={() => {
          consultantStore.setReview(starRating, comment);
          consultantStore.postReviewForSelectedConsultant(commonStore.token);
          consultantStore.updateReviewsForSelectedConsultant(
            starRating,
            comment
          );
        }}
        success
      >
        <Form.TextArea
          placeholder="Type your review here..."
          onChange={handleOnChangeTextReview}
        />
        {/* <Message
          success
          header="Review Completed"
          content="Thank you for your submission!"
        /> */}
        <Button floated="right" positive type="submit" content="Add Review" />
      </Form>
      <Card.Content extra>
        <Button.Group widths="3">
          <Button
            as={NavLink}
            to="/consultants/hire"
            basic
            color="green"
            content="Hire"
          />
          <Button
            as={Link}
            to={`/consultants/${consultantStore.selectedConsultant?.id}`}
            basic
            color="black"
            content="View Profile"
          />
          <Button
            onClick={commonStore.setDisplayConsultantContact}
            basic
            color="blue"
            content="Message"
          />
        </Button.Group>
      </Card.Content>
    </Card>
  );
});
