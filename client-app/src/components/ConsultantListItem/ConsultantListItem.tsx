import React from "react";
import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import {
  Button,
  Icon,
  Item,
  Label,
  Progress,
  Rating,
  Segment,
} from "semantic-ui-react";
import { Consultant } from "../../models/consultant";
import { useStore } from "../../stores/store";

import HomerImage from "../../assets/homersimpson.0.0.jpg";

interface Props {
  consultant: Consultant;
}

export default observer(function ConsultantListItem({ consultant }: Props) {
  const { consultantStore } = useStore();

  const calculateLevel = (totalStarRating: number) => {
    if (totalStarRating < 5)
      return [Math.floor((totalStarRating / 5) * 100), 1];
    let starRating: number = totalStarRating;
    let level: number = 1;
    let lowerLimit: number = 1;
    let upperLimit: number = 5;
    let percentage: number = 0;

    while (Math.floor(totalStarRating / 5) !== 0) {
      level++;
      lowerLimit *= 5;
      upperLimit *= 5;
      totalStarRating = Math.floor(totalStarRating / 5);
    }

    percentage = ((starRating - lowerLimit) * 100) / (upperLimit - lowerLimit);

    return [percentage, level];
  };

  const [percentage, level] = calculateLevel(consultant.totalStarRating);

  return (
    <Segment.Group>
      <Segment>
        <Item.Group>
          <Item>
            <Item.Image size="tiny" circular src={HomerImage} alt="photo" />
            <Item.Content>
              <Item.Header as={Link} to={`/consultants/${consultant.id}`}>
                {consultant.displayName}
              </Item.Header>
              <Item.Description>{consultant.bio}</Item.Description>
            </Item.Content>
          </Item>
        </Item.Group>
      </Segment>
      <Item>
        <Rating
          icon="star"
          defaultRating={consultant.averageStarReview}
          maxRating={5}
          disabled
          size="huge"
        />
      </Item>
      <Item.Extra>
        <Label
          basic
          content={
            consultant.reviews.length !== 0 ? consultant.reviews[0].comment : 0
          }
        />
      </Item.Extra>
      <Segment>
        <span>
          <Icon name="checkmark" />{" "}
          {consultant.reviews.length !== 0 ? consultant.reviews.length : 0}{" "}
          reviews
        </span>
      </Segment>
      <Segment.Group horizontal secondary clearing>
        <Segment>123 Followers 45 Following</Segment>
        <Segment>
          <Progress percent={percentage} style={{ width: "17em" }} success>
            {consultant.categories[0]} Level: {level}
          </Progress>
        </Segment>
        <Segment>
          <Button
            onClick={() => consultantStore.selectConsultant(consultant.id)}
            floated="right"
            content="View"
            color="blue"
          />
        </Segment>
      </Segment.Group>
    </Segment.Group>
  );
});
