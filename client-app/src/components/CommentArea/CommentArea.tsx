import React, { useEffect } from "react";
import { ChatComment } from "../../models/comment";
import { Post } from "../../models/post";
import { useStore } from "../../stores/store";
import CommentItem from "../CommentItem/CommentItem";
import PostComment from "../PostComment/PostComment";

interface Props {
  post: Post;
}
export default function CommentArea({ post }: Props) {
  const { commentStore } = useStore();

  useEffect(() => {
    if (post.id) {
      commentStore.createHubConnection(post.id);
    }
    return () => {
      commentStore.clearComments();
    };
  }, [commentStore, post.id]);

  return (
    <div>
      <PostComment />
      {commentStore.comments.map((comment: ChatComment) => (
        <CommentItem comment={comment} />
      ))}
    </div>
  );
}
