import { observer } from "mobx-react-lite";
import React from "react";
import { Link } from "react-router-dom";
import { Button, Container, Header, Image, Segment } from "semantic-ui-react";
import { useStore } from "../../stores/store";

export default observer(function HomePage() {
  const { userStore } = useStore();

  return (
    <Segment inverted textAlign="center" vertical className="masthead">
      <Container text>
        <Header as="h1" inverted>
          <Image
            size="massive"
            src="/assets/logo.png"
            alt="logo"
            style={{ marginBottom: 12 }}
          />
          Consulting Match
        </Header>
        <Header as="h2" inverted content="Welcome to ConsultingMatch" />
        {userStore.isLoggedIn ? (
          <Button as={Link} to="/consultants" size="huge" inverted>
            Find a consultant!
          </Button>
        ) : (
          <Button.Group widths="2">
            <Button as={Link} to="/login" size="huge" inverted>
              Login!
            </Button>
            <Button as={Link} to="/register" size="huge" inverted>
              Register
            </Button>
          </Button.Group>
        )}
      </Container>
    </Segment>
  );
});
