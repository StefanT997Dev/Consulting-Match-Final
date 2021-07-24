import React from "react";
import {
  Button,
  ButtonOr,
  Confirm,
  Grid,
  GridColumn,
  Item,
  Progress,
  Segment,
} from "semantic-ui-react";
import { useStore } from "../../stores/store";
import HomerImage from "../../assets/homersimpson.0.0.jpg";
import agent from "../../api/agent";
import { useEffect } from "react";
import { FollowStats } from "../../models/followStats";
import { useState } from "react";
import ProfileStats from "./ProfileStats";
import ScheduleDashboard from "../Scheduler/ScheduleDashboard";
import { Consultant } from "../../models/consultant";
export default function ProfileHeader() {
  const { consultantStore, commonStore } = useStore();

  const followToggle = async (
    targetUsername: string | undefined,
    token: string | null
  ) => {
    await agent.Consultants.followToggle(targetUsername, token).then((_) => {
      isFollowed();
      getFollowStats();
    });
  };

  const [isFollowingSelectedUser, setIsFollowingSelectedUser] =
    useState<boolean>(false);

  const [currentConsultant, setCurrentConsultant] = useState<Consultant>();

  const [open, setOpen] = useState<boolean>(false);
  const [openSchedulerDashboard, setOpenSchedulerDashboard] =
    useState<boolean>(false);

  const [followStats, setFollowStats] = useState<FollowStats>({
    followers: 0,
    following: 0,
  });

  const toggleOpen = () => {
    setOpen(!open);
  };

  const isFollowed = async () => {
    const result = await agent.Consultants.isFollowed(
      consultantStore.selectedConsultant?.id,
      commonStore.token
    ).then((response) => {
      setIsFollowingSelectedUser(response.isFollowed);
    });
  };

  const getFollowStats = async () => {
    await agent.Consultants.getFollowStats(
      consultantStore.selectedConsultant?.id,
      commonStore.token
    ).then((response) => {
      setFollowStats({
        followers: response.followers,
        following: response.following,
      });
    });
  };

  const toggleOpenSchedulerDashboard = () => {
    setOpenSchedulerDashboard(!openSchedulerDashboard);
  };

  const getCurrentConsultant = () => {
    debugger
    if (window.location.href.substring(22) === "profile") {
      agent.Consultants.getCurrentConsultant(
        commonStore.getUserObject().id
      ).then((response) => {
        setCurrentConsultant(response);
      });
    } else {
      agent.Consultants.getCurrentConsultant(
        window.location.href.substring(34)
      ).then((response) => {
        setCurrentConsultant(response);
      });
    }
  };

  useEffect(() => {
    isFollowed();
    getFollowStats();
    getCurrentConsultant();
  }, []);

  return (
    <div>
      <Segment>
        <Item.Group>
          <Item>
            <Item.Image src={HomerImage} size="small" />
            <Item.Content>
              <Grid>
                <Grid.Row>
                  <Grid.Column width="6">
                    <Item.Group>
                      <Item>
                        <Item.Header>
                          {currentConsultant?currentConsultant.displayName:null}
                        </Item.Header>
                      </Item>
                    </Item.Group>
                    <Item.Description>
                      {currentConsultant?currentConsultant.bio:null}
                    </Item.Description>
                    <Progress
                      percent={50}
                      style={{ width: "17em", marginBottom: "4em" }}
                      success
                    >
                      {currentConsultant?currentConsultant.categories[0]:null} Level:{" "}
                      {4}
                    </Progress>
                  </Grid.Column>
                  <Grid.Column verticalAlign="middle" width="4">
                    <Item.Content
                      style={{
                        fontSize: "xx-large",
                        fontStyle: "bold",
                      }}
                    >
                      {followStats.followers} Followers
                    </Item.Content>
                  </Grid.Column>
                  <Grid.Column verticalAlign="middle" width="6">
                    <Item.Content
                      style={{ fontSize: "xx-large", fontStyle: "bold" }}
                    >
                      {followStats.following} Following
                    </Item.Content>
                  </Grid.Column>
                  <GridColumn width="6"></GridColumn>
                  <GridColumn textAlign="center" width="7">
                    <Button
                      onClick={toggleOpen}
                      style={{ marginBottom: "3rem" }}
                      primary
                    >
                      Check dashboard
                    </Button>
                    <Confirm
                      open={open}
                      header="List of followers and following"
                      content={<ProfileStats />}
                      onCancel={toggleOpen}
                      onConfirm={toggleOpen}
                    />
                  </GridColumn>
                </Grid.Row>
              </Grid>
              <Button.Group widths="2">
                <Button
                  onClick={toggleOpenSchedulerDashboard}
                  floated="right"
                  positive
                >
                  Hire
                </Button>
                <Button
                  onClick={() =>
                    followToggle(
                      consultantStore.selectedConsultant?.displayName,
                      commonStore.token
                    )
                  }
                  floated="right"
                  primary
                >
                  {isFollowingSelectedUser ? "Unfollow" : "Follow"}
                </Button>
              </Button.Group>
            </Item.Content>
          </Item>
        </Item.Group>

        <Confirm
          open={openSchedulerDashboard}
          header="Consulting Scheduler"
          content={<ScheduleDashboard />}
          onCancel={toggleOpenSchedulerDashboard}
          onConfirm={toggleOpenSchedulerDashboard}
        />
      </Segment>
    </div>
  );
}
