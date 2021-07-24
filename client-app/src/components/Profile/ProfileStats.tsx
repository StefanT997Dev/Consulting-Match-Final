import axios from "axios";
import React, { useState } from "react";
import { useEffect } from "react";
import { Card, Grid, Image, List } from "semantic-ui-react";
import agent from "../../api/agent";
import { DashboardStats } from "../../models/dashboardStats";
import { useStore } from "../../stores/store";

export default function ProfileStats() {
  const { consultantStore } = useStore();
  const [followersAndFollowing, setFollowersAndFollowing] =
    useState<DashboardStats>({ followers: [], following: [] });

  const getListOfFollowersAndFollowing = async () => {
    await agent.Consultants.getFollowersAndFollowing(
      consultantStore.selectedConsultant?.id
    ).then((response) => {
      setFollowersAndFollowing(response);
    });
  };

  useEffect(()=>{
    getListOfFollowersAndFollowing();
  },[])

  return (
    <Grid>
      <Grid.Column width="2"></Grid.Column>
      <Grid.Column textAlign="center" width="5">
        <Card style={{boxShadow: 'none'}}>
          <Card.Header>
            <b>Followers:</b>
          </Card.Header>
          <List>
            {followersAndFollowing.followers.map((user) => (
              <List.Item key={user.id}>
                <Image
                  avatar
                  src="https://react.semantic-ui.com/images/avatar/small/rachel.png"
                />
                <List.Content>
                  <List.Header as="a">{user.displayName}</List.Header>
                  <List.Description>Sitecore Consultant</List.Description>
                </List.Content>
              </List.Item>
            ))}
          </List>
        </Card>
      </Grid.Column>
      <Grid.Column width="2"></Grid.Column>
      <Grid.Column textAlign="center" width="5">
        <Card style={{boxShadow: 'none'}}>
          <Card.Header>
            <b>Following:</b>
          </Card.Header>
          <List>
            {followersAndFollowing.following.map((user) => (
              <List.Item key={user.id}>
                <Image
                  avatar
                  src="https://react.semantic-ui.com/images/avatar/small/rachel.png"
                />
                <List.Content>
                  <List.Header as="a">{user.displayName}</List.Header>
                  <List.Description>Sitecore Consultant</List.Description>
                </List.Content>
              </List.Item>
            ))}
          </List>
        </Card>
      </Grid.Column>
      <Grid.Column width="2"></Grid.Column>
    </Grid>
  );
}
