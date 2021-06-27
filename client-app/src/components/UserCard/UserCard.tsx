import React from "react";
import { Card, Image } from "semantic-ui-react";

import HomerImage from "../../assets/homersimpson.0.0.jpg";

import "./UserCard.scss";

type UserCardProps = {
  id?: string;
  displayName: string;
  image?: string;
};

const UserCard: React.FC<UserCardProps> = (props) => {
  const { id, displayName, image, children } = props;

  return (
    <Card key={id} className="user-card">
      <Image src={image ? image : HomerImage} alt="profile image" />
      <Card.Content>{displayName}</Card.Content>
      <Card.Content extra>{children}</Card.Content>
    </Card>
  );
};

export default UserCard;
