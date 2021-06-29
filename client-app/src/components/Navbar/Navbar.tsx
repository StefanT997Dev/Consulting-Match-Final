import { observer } from "mobx-react-lite";
import React, { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import { history } from "../../";
import {
  Button,
  Container,
  Menu,
  Sidebar,
  Grid,
  Icon,
  Search,
  Segment,
  SearchProps,
} from "semantic-ui-react";
import agent from "../../api/agent";
import { MAX_MOBILE_SCREEN_WIDTH } from "../../constants";
import { isEmptyObject } from "../../util/data";
import { Category } from "../../models/category";
import { useStore } from "../../stores/store";

import "./Navbar.scss";

export default observer(function Navbar() {
  const currentUser = JSON.parse(localStorage.getItem("user") || "{}");
  const isLoggedIn = !isEmptyObject(currentUser);
  const isAdmin = currentUser ? currentUser.role === "admin" : false;

  const { consultantStore } = useStore();
  const {
    userStore: { user, logout },
  } = useStore();

  const [categories, setCategories] = useState<Category[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [searchedName, setSearchedName] = useState<string | undefined>("");

  const [width, setWidth] = useState(window.innerWidth);
  const [sidebarVisible, setSidebarVisible] = useState(false);

  useEffect(() => {
    agent.Categories.list().then((response) => {
      setCategories(response);
    });
  }, []);

  useEffect(() => {
    const handleResize = () => {
      setWidth(window.innerWidth);
      if (window.innerWidth > MAX_MOBILE_SCREEN_WIDTH) setSidebarVisible(false);
    };

    window.addEventListener("resize", handleResize);
    return () => window.removeEventListener("resize", handleResize);
  }, []);

  const handleSearchChange = (
    event: React.MouseEvent<HTMLElement, MouseEvent>,
    data: SearchProps
  ) => {
    setIsLoading(true);
    setSearchedName(data.value);

    consultantStore.filterConsultants(data.value);
  };

  const tabs = (
    <React.Fragment>
      <Menu.Item as={NavLink} to="/" exact>
        Home
      </Menu.Item>
      {!isLoggedIn ? (
        <Menu.Item header as={NavLink} to="/authentication" exact>
          ConsultingMatch
        </Menu.Item>
      ) : null}
      {isAdmin && (
        <Menu.Item as={NavLink} to="/manage">
          Admin panel
        </Menu.Item>
      )}
      {/* <Menu.Item name="Feed" as={NavLink} to="/feed" /> */}
      <Menu.Item as={NavLink} to="/profile" exact>
        Profile
      </Menu.Item>
      {/* <Menu.Item style={{ width: "45em" }}>
        <Grid>
          <Grid.Column width={8}>
            <Search
              fluid
              input={{ fluid: true }}
              style={{ width: "600px" }}
              loading={isLoading}
              onSearchChange={handleSearchChange}
              results={consultantStore.filteredConsultants}
              value={searchedName}
            />
          </Grid.Column>
        </Grid>
      </Menu.Item> */}
      {isLoggedIn && (
        <Menu.Item
          onClick={() => {
            logout();
            // history.push("/");
            history.replace("/");
          }}
          position="right"
        >
          Logout
        </Menu.Item>
      )}
    </React.Fragment>
  );

  console.log("tabs", tabs);

  return (
    <div>
      {width > MAX_MOBILE_SCREEN_WIDTH ? (
        <Menu
          className="navbar"
          style={{ marginTop: "0px", marginBottom: "0px" }}
          inverted
        >
          {tabs}
        </Menu>
      ) : (
        <Segment className="navbar" inverted size="tiny">
          <Icon
            size="big"
            name="sidebar"
            onClick={() => setSidebarVisible(true)}
          />
          <Sidebar
            inverted
            as={Menu}
            width="thin"
            vertical
            visible={sidebarVisible}
            onHinde={() => setSidebarVisible(false)}
          >
            {tabs}
          </Sidebar>
        </Segment>
      )}
    </div>
  );
});
