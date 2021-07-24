import React, { useEffect } from "react";
import { Container } from "semantic-ui-react";
import { useStore } from "../../stores/store";
import ProfileFeed from "./ProfileFeed";
import ProfileHeader from "./ProfileHeader";

export default function Profile() {
  const { consultantStore } = useStore();
  const { reviewStore } = useStore();
  const { postStore } = useStore();

  useEffect(() => {
    reviewStore.getReviewsForSelectedConsultant(
      consultantStore.selectedConsultant
    );
    postStore.getListOfPostsForSelectedConsultant(
      consultantStore.selectedConsultant
    );
  }, [reviewStore, postStore, consultantStore]);

  return (
    <Container>
      <ProfileHeader />
      <ProfileFeed />
    </Container>
  );
}
