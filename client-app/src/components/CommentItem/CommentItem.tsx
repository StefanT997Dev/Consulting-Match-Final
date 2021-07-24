import React from "react";
import { Comment, Item, Segment } from "semantic-ui-react";
import { ChatComment } from "../../models/comment";

import HomerImage from "../../assets/homersimpson.0.0.jpg";

interface Props {
  comment: ChatComment;
}

export default function CommentItem({ comment }: Props) {
  return (
    <Segment>
      <Comment key={comment.id}>
        <Item>
          <Item.Image size="tiny" circular src={HomerImage} />
        </Item>
        <Comment.Content>
          <Comment.Author as="a">{comment.displayName}</Comment.Author>
          <Comment.Metadata>
            <div>{comment.createdAt}</div>
          </Comment.Metadata>
          <Comment.Text>{comment.body}</Comment.Text>
          <Comment.Actions>
            <Comment.Action>Reply</Comment.Action>
          </Comment.Actions>
        </Comment.Content>
      </Comment>
    </Segment>
  );
}
