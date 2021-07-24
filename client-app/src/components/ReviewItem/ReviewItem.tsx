import React from "react";
import { Item, Label, Rating, Segment } from "semantic-ui-react";
import { Review } from "../../models/review";

import HomerImage from "../../assets/homersimpson.0.0.jpg";

interface Props {
  review: Review;
}

export default function ReviewItem({ review }: Props) {
  return (
    <Segment>
      <Item.Group>
        <Item.Image size="tiny" circular src={HomerImage} alt="photo" />
        <Rating
          icon="star"
          defaultRating={review.starRating}
          maxRating={5}
          disabled
          size="huge"
        />
        <Item.Extra>
          <Label basic content={review.comment} />
        </Item.Extra>
      </Item.Group>
    </Segment>
  );
}
